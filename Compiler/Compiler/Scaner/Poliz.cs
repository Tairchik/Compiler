using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public class Poliz
    {
        private List<List<Token>> _codeLines;

        private readonly Dictionary<TokenType, int> _priority = new()
        {
            { TokenType.OpenParen, 0 },
            { TokenType.CloseParen, 1 },
            { TokenType.Plus, 2 },
            { TokenType.Minus, 2 },
            { TokenType.Multiply, 3 },
            { TokenType.Divide, 3 },
            { TokenType.IntDivide, 3 },
            { TokenType.Mod, 3 },
            { TokenType.Power, 4 }
        };

        public Poliz() 
        {
            _codeLines = new List<List<Token>>();
        }

        public List<List<string>> Generate(List<Token> tokens) 
        {
            ConvertTokensToLinesCode(tokens);
            List <List<string>> res = new List<List<string>>();
            foreach (var tok in _codeLines) 
            {
                res.Add(CreatePoliz(tok));
            }
            return res;
        }

        private List<string> CreatePoliz(List<Token> tokens)
        {
            List<string> output = new List<string>();
            Stack<Token> operators = new Stack<Token>();

            var cleanTokens = tokens.Where(t => t.Type != TokenType.WhiteSpace && t.Type != TokenType.Semicolon);

            foreach (var token in cleanTokens)
            {
                if (token.Type == TokenType.ConstInt || token.Type == TokenType.Id)
                {
                    output.Add(token.Value);
                }
                else if (token.Type == TokenType.OpenParen)
                {
                    operators.Push(token);
                }
                else if (token.Type == TokenType.CloseParen)
                {
                    while (operators.Count > 0 && operators.Peek().Type != TokenType.OpenParen)
                    {
                        output.Add(operators.Pop().Value);
                    }
                    if (operators.Count > 0) operators.Pop(); // Убираем '('
                }
                else if (_priority.ContainsKey(token.Type))
                {
                    while (operators.Count > 0 && _priority[operators.Peek().Type] >= _priority[token.Type])
                    {
                        output.Add(operators.Pop().Value);
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop().Value);
            }

            return output;
        }

        public double Evaluate(List<string> poliz)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var item in poliz)
            {
                if (int.TryParse(item, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (item)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push((double) a / (double) b); break; 
                        case "//": stack.Push((int)a / (int)b); break; 
                        case "%": stack.Push(a % b); break;
                        case "**": stack.Push(Math.Pow(a, b)); break;
                        default: throw new ArgumentException("Некорректная входящая строка");
                    }
                }
            }

            return stack.Pop();
        }

        public string GetStringByExp(List<string> parts) 
        {
            string res = "";
            foreach (var el in parts) 
            {
                res += el;
            }

            return res;
        }
        private void ConvertTokensToLinesCode(List<Token> tokens)
        {
            List<Token> line = new List<Token>();
            foreach (var tok in tokens)
            {
                if (tok.Type != TokenType.WhiteSpace)
                {
                    if (tok.Type == TokenType.Semicolon)
                    {
                        _codeLines.Add(line);
                        line = new List<Token>();
                    }
                    else
                    {
                        line.Add(tok);
                    }
                }
            }
        }
    }
}
