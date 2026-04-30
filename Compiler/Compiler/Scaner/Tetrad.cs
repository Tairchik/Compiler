using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public class Tetrad 
    {
        public string Oper { get; set; } = "";
        public string Arg1 { get; set; } = "";
        public string Arg2 { get; set; } = "";
        public string Res { get; set; } = "";

        public string FullExpression => $"{Res} = {Arg1} {Oper} {Arg2}";
    }

    public class Tetrads
    {
        private List<Token> _tokens;
        private List<List<Token>> _codeLines;
        private int _tempCount = 0;
        private readonly Dictionary<TokenType, int> _priority = new()
        {
            { TokenType.OpenParen, 0 },
            { TokenType.Plus, 1 },
            { TokenType.Minus, 1 },
            { TokenType.Multiply, 2 },
            { TokenType.Divide, 2 },
            { TokenType.IntDivide, 2 },
            { TokenType.Mod, 2 },
            { TokenType.Power, 3 },
        };

        public Tetrads(List<Token> tokens) 
        {
            _tokens = tokens;
            _codeLines = new List<List<Token>>();
        }

        public List<(string, List<Tetrad>)>? Generate() 
        {
            if (_tokens == null || _tokens.Count == 0)
                return null;

            ConvertTokensToLinesCode();
            List<Tetrad> tetrads;
            List<(string, List<Tetrad>)> res = new List<(string, List<Tetrad>)> ();

            foreach (var line in _codeLines)
            {
                tetrads = new List<Tetrad>();
                GenerateForLine(line, tetrads);
                string line_str = GetStrByLine(line);
                res.Add((line_str, tetrads));
            }

            return res;
        }

        private string GetStrByLine(List<Token> line) 
        {
            string res = "";
            bool c = false;
            foreach (var token in line) 
            {
                if (c == false)
                {
                    res += $"{token.Value}";
                    c = true;
                    continue;
                }
                res += $" {token.Value}";
            }

            return res;
        }
        private void ConvertTokensToLinesCode()
        {
            List<Token> line = new List<Token>();
            foreach (var tok in _tokens)
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
        private void GenerateForLine(List<Token> line, List<Tetrad> tetrads)
        {
            Stack<string> operands = new Stack<string>();
            Stack<Token> operators = new Stack<Token>();
            _tempCount = 0;

            foreach (var token in line)
            {
                if (token.Type == TokenType.ConstInt || token.Type == TokenType.Id)
                {
                    operands.Push(token.Value);
                }
                else if (token.Type == TokenType.OpenParen)
                {
                    operators.Push(token);
                }
                else if (token.Type == TokenType.CloseParen)
                {
                    while (operators.Count > 0 && operators.Peek().Type != TokenType.OpenParen)
                    {
                        CreateTetrad(operators.Pop(), operands, tetrads);
                    }
                    if (operators.Count > 0) operators.Pop();
                }
                else if (_priority.ContainsKey(token.Type))
                {
                    while (operators.Count > 0 && _priority[operators.Peek().Type] >= _priority[token.Type])
                    {
                        CreateTetrad(operators.Pop(), operands, tetrads);
                    }
                    operators.Push(token);
                }
            }

            // Выталкиваем оставшиеся операторы в конце строки
            while (operators.Count > 0)
            {
                CreateTetrad(operators.Pop(), operands, tetrads);
            }
        }

        private string NewTemp()
        {
            _tempCount++;
            return $"t{_tempCount}";
        }
        private void CreateTetrad(Token opToken, Stack<string> operands, List<Tetrad> tetrads)
        {
            string right = operands.Pop();
            string left = operands.Pop();
            string temp = NewTemp();

            tetrads.Add(new Tetrad
            {
                Oper = opToken.Value,
                Arg1 = left,
                Arg2 = right,
                Res = temp
            });

            operands.Push(temp);
        }
    }
}
