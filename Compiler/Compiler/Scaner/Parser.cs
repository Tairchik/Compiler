using System;
using System.Collections.Generic;
using System.Linq;

namespace CompilerGUI.Scaner
{
    public class SyntaxError
    {
        public int Line;
        public int StartPos;
        public int EndPos;
        public int AbsoluteIndex;
        public string Message = "";
        public string Value = "";

        public SyntaxError(int line, int start_pos, int end_pos, int abs_index, string message, string value)
        {
            Line = line;
            StartPos = start_pos;
            EndPos = end_pos;
            AbsoluteIndex = abs_index;
            Message = message;
            Value = value;
        }
    }

    public class Parser
    {
        private List<Token> _tokens = new();
        private int _pos = 0;
        private List<SyntaxError> _errors = new();
        public List<SyntaxError>? Parse(List<Token> tokens)
        {
            // Убираем пробелы
            _tokens = tokens.Where(t => t.Type != TokenType.WhiteSpace).ToList();
            _pos = 0;
            _errors.Clear();

            // Основной цикл: парсим выражения, разделенные ';'
            while (_pos < _tokens.Count)
            {
                ParseExpressionStatement();
            }

            return _errors.Count > 0 ? _errors : null;
        }

        private Token? Current => _pos < _tokens.Count ? _tokens[_pos] : null;

        private void Next()
        {
            if (_pos < _tokens.Count) _pos++;
        }

        private bool Match(TokenType type)
        {
            if (Current?.Type == type)
            {
                Next();
                return true;
            }

            AddError($"Ожидался '{TokenToString.GetString(type)}', найдено '{(Current != null ? TokenToString.GetString(Current.Type) : "EOF")}'");
            return false;
        }

        private void AddError(string message)
        {
            Token? t = Current ?? (_tokens.Count > 0 ? _tokens[^1] : null);

            if (t == null) return;

            _errors.Add(new SyntaxError(
                t.Line,
                t.StartPos,
                t.EndPos,
                t.AbsoluteIndex,
                message,
                t.Value
            ));
        }

        private void SkipTo(params TokenType[] syncTokens)
        {
            while (Current != null && !syncTokens.Contains(Current.Type))
            {
                Next();
            }
        }

        // Обработка одной строки (выражение + ;)
        private void ParseExpressionStatement()
        {
            ParseE(); // Запуск E -> TA
        }

        // E -> TA
        private void ParseE()
        {
            ParseT();
            ParseA();
        }

        // A -> ; | + TA | - TA
        private void ParseA()
        {
            if (Current == null)
            {
                AddError("Неожиданный конец выражения");
                return;
            }
            if (Current?.Type == TokenType.Plus || Current?.Type == TokenType.Minus)
            {
                Next();
                ParseT();
                ParseA();
            }
            else if (Current?.Type == TokenType.Semicolon)
            {
                Next();
            }
            else
            {
                int pos_l = _pos;
                string? val_l = Current?.Value;
                SkipTo(TokenType.ConstInt, TokenType.Id, TokenType.OpenParen, TokenType.Semicolon);
                if (pos_l == _pos)
                    AddError($"Пропущен арифметический знак");
                else 
                {
                    int tmp = _pos;
                    _pos = pos_l;
                    AddError($"Недопустимый символ в выражении: '{val_l}'");
                    _pos = tmp;
                }
                if (Current?.Type == TokenType.Semicolon)
                {
                    Next();
                    return;
                }
                ParseT();
                ParseA();
            }
        }

        // T -> FB
        private void ParseT()
        {
            ParseF();
            ParseB();
        }

        // B -> e | * FB | / FB | // FB | % FB | ** FB
        private void ParseB()
        {
            if (Current?.Type == TokenType.Multiply ||
                Current?.Type == TokenType.Divide ||
                Current?.Type == TokenType.IntDivide ||
                Current?.Type == TokenType.Mod ||
                Current?.Type == TokenType.Power)
            {
                Next();
                ParseF();
                ParseB();
            }
        }

        // F -> num | id | (E)
        private void ParseF()
        {
            if (Current == null)
            {
                return;
            }

            switch (Current?.Type)
            {
                case TokenType.ConstInt:
                    Next();
                    break;

                case TokenType.Id:
                    Next();
                    break;

                case TokenType.OpenParen:
                    Next();
                    if (Current?.Type == TokenType.CloseParen)
                    {
                        AddError($"Пропущена переменная, константа или открывающая скобка");
                        Next();
                        return;
                    }
                    ParseParenE();

                    if (Match(TokenType.CloseParen) == false) 
                    {
                        SkipTo(TokenType.Semicolon, TokenType.Multiply, TokenType.Divide, 
                            TokenType.IntDivide, TokenType.Power, TokenType.Plus, TokenType.Minus, TokenType.Mod);
                    }
                    break;

                default:
                    int pos_l = _pos;
                    string? val_l = Current?.Value;
                    SkipTo(TokenType.Semicolon, TokenType.Multiply, TokenType.Divide,
                        TokenType.IntDivide, TokenType.Power, TokenType.Plus, TokenType.Minus, TokenType.Mod);

                    if (pos_l == _pos)
                        AddError($"Пропущена переменная, константа или открывающая скобка");
                    else
                    {
                        int tmp = _pos;
                        _pos = pos_l;
                        AddError($"Недопустимый символ в выражении: '{val_l}'");
                        _pos = tmp;
                    }
                    break;
            }
        }

        private void ParseParenE()
        {
            ParseParenT();
            ParseParenA();
        }

        private void ParseParenT()
        {
            ParseParenF();
            ParseParenB();
        }
        private void ParseParenA()
        {
            if (Current == null)
            {
                AddError("Неожиданный конец выражения");
                return;
            }
            if (Current?.Type == TokenType.Plus || Current?.Type == TokenType.Minus)
            {
                Next();
                ParseParenE();
            }
            else if (Current?.Type == TokenType.CloseParen)
            {
                return;
            }
            else
            {
                if (Current?.Type == TokenType.Semicolon) return;
                int pos_l = _pos;
                string? val_l = Current?.Value;

                SkipTo(TokenType.ConstInt, TokenType.Id, TokenType.CloseParen, TokenType.Semicolon);
                if (pos_l == _pos)
                    AddError($"Пропущен арифметический знак");
                else
                {
                    int tmp = _pos;
                    _pos = pos_l;
                    AddError($"Недопустимый символ в выражении: '{val_l}'");
                    _pos = tmp;
                }
                if (Current == null || Current.Type == TokenType.Semicolon) return;
                if (Current?.Type == TokenType.CloseParen) return;
                ParseParenT();
                ParseParenA();
            }
        }
        private void ParseParenB()
        {
            if (Current?.Type == TokenType.Multiply ||
                Current?.Type == TokenType.Divide ||
                Current?.Type == TokenType.IntDivide ||
                Current?.Type == TokenType.Mod ||
                Current?.Type == TokenType.Power)
            {
                Next();
                if (Current?.Type == TokenType.CloseParen) 
                {
                    AddError($"Пропущена переменная, константа или открывающая скобка");
                    return;
                }
                ParseParenF();
                ParseParenB();
            }
        }
        private void ParseParenF()
        {
            if (Current == null)
            {
                return;
            }

            switch (Current?.Type)
            {
                case TokenType.ConstInt:
                    Next();
                    break;

                case TokenType.Id:
                    Next();
                    break;

                case TokenType.OpenParen:
                    Next();
                    if (Current?.Type == TokenType.CloseParen) 
                    {
                        AddError($"Пропущена переменная, константа или открывающая скобка");
                        Next();
                        return;
                    }
                    ParseParenE();

                    if (Match(TokenType.CloseParen) == false)
                    {
                        SkipTo(TokenType.Semicolon, TokenType.Multiply, TokenType.Divide,
                            TokenType.IntDivide, TokenType.Power, TokenType.Plus, TokenType.Minus, TokenType.Mod);
                    }
                    break;
                case TokenType.CloseParen:
                    break;
                default:
                    int pos_l = _pos;
                    string? val_l = Current?.Value;
                    SkipTo(TokenType.Semicolon, TokenType.Multiply, TokenType.Divide,
                        TokenType.IntDivide, TokenType.Power, TokenType.Plus, TokenType.Minus, TokenType.Mod);

                    if (pos_l == _pos)
                        AddError($"Пропущена переменная, константа или открывающая скобка");
                    else
                    {
                        int tmp = _pos;
                        _pos = pos_l;
                        AddError($"Недопустимый символ в выражении: '{val_l}'");
                        _pos = tmp;
                    }
                    break;
            }
        }


    }
}
