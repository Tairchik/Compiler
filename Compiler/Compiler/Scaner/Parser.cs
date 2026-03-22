using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLangParser;


namespace CompilerGUI.Scaner
{
    public class Parser
    {
        private List<Token> _tokens = new();
        private int _pos = 0;
        private List<SyntaxError> _errors = new();

        public List<SyntaxError>? Parse(List<Token> tokens)
        {
            _tokens = tokens
                .Where(t => t.Type != TokenType.WhiteSpace)
                .ToList();

            _pos = 0;
            _errors.Clear();

            while (_pos < _tokens.Count)
            {
                int start = _pos;

                ParseZ();

                if (_pos == start)
                    Next();
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

            AddError($"Ожидался \'{TokenToString.GetString(type)}\', найдено \'{Current?.TypeName}\'");
            return false;
        }

        private void AddError(string message)
        {
            Token? t = Current;

            if (t == null)
            {
                if (_tokens.Count == 0) return;

                t = _tokens[^1];
                _errors.Add(new SyntaxError(
                    t.Line,
                    t.EndPos + 1,   // позиция ПОСЛЕ токена
                    t.EndPos + 1,
                    t.AbsoluteIndex + 1,
                    message,
                    t.Value
                 ));
                return;
            }

            _errors.Add(new SyntaxError(
                t.Line,
                t.StartPos,
                t.EndPos,
                t.AbsoluteIndex,
                message,
                t.Value
            ));
        }

        // МЕТОД АЙРОНСА
        private void SkipTo(params TokenType[] syncTokens)
        {
            while (Current != null && !syncTokens.Contains(Current.Type))
            {
                Next();
            }
        }

        // ГРАММАТИКА
        private void ParseZ()
        {
            bool skip_list_elements = false;
            if (!Match(TokenType.Id))
            {
                SkipTo(TokenType.Equal, TokenType.End_operator, TokenType.OpenListDelimiter);
            }

            if (!Match(TokenType.Equal))
            {
                SkipTo(TokenType.OpenListDelimiter, TokenType.End_operator, TokenType.CloseListDelimiter);
            }

            if (!Match(TokenType.OpenListDelimiter))
            {
                SkipTo(TokenType.CloseListDelimiter, TokenType.ConstFloat, TokenType.ConstInt, TokenType.ConstString, 
                    TokenType.ConstTrue, TokenType.ConstFalse, TokenType.Plus, TokenType.Minus, TokenType.End_operator);
            }
            if (Current?.Type == TokenType.CloseListDelimiter)
            {
                Next();
            }
            else
            {
                ParseElements();

                if (!Match(TokenType.CloseListDelimiter))
                {
                    SkipTo(TokenType.End_operator);
                }
            }

            if (Current?.Type == TokenType.End_operator)
            {
                Next();
            }
            else
            {
                AddError("Ожидалась ';' в конце оператора");
                return;
                // если не конец файла — делаем восстановление
                if (Current != null)
                {
                    SkipTo(TokenType.End_operator, TokenType.Id);

                    if (Current?.Type == TokenType.End_operator)
                        Next();
                }
            }
        }

        private void ParseElements()
        {
            int res = FirstParseConst();
            if (res == 1 && Current?.Type == TokenType.End_operator) 
            {
                return;
            }
            else if (res == 1) 
            {
                // [error]
                if (Current?.Type == TokenType.CloseListDelimiter)
                {
                    _pos--;
                    AddError("Ожидалась константа");
                    Next();
                    return;
                }
                // Для запятой [,]   
                Next();
                if (Current?.Type == TokenType.CloseListDelimiter) 
                {
                    _pos--;
                    AddError("Ожидалась константа");
                    Next();
                    return;
                }
                // [error ... ]
                _pos--;
                AddError("Ожидалась константа");
            }

            while (true)
            {
                if (Current?.Type == TokenType.Comma)
                {
                    Next();

                    if (Current?.Type == TokenType.CloseListDelimiter)
                    {
                        AddError("После запятой ожидается элемент");
                        return;
                    }

                    ParseConst();
                }
                else break;
            }
        }

        private int ParseConst()
        {
            ParseSign();

            if (Current == null) return 0;

            switch (Current.Type)
            {
                case TokenType.ConstInt:
                case TokenType.ConstFloat:
                case TokenType.ConstString:
                case TokenType.ConstTrue:
                case TokenType.ConstFalse:
                    Next();
                    return 0;

                default:
                    AddError("Ожидалась константа");
                    // ВОССТАНОВЛЕНИЕ
                    SkipTo(TokenType.Comma, TokenType.CloseListDelimiter, TokenType.End_operator, TokenType.ConstFloat, TokenType.ConstInt, TokenType.ConstString,
                    TokenType.ConstTrue, TokenType.ConstFalse, TokenType.Plus, TokenType.Minus);
                    return 1;
            }
        }

        private int FirstParseConst()
        {
            ParseSign();

            if (Current == null) return 0;

            switch (Current.Type)
            {
                case TokenType.ConstInt:
                case TokenType.ConstFloat:
                case TokenType.ConstString:
                case TokenType.ConstTrue:
                case TokenType.ConstFalse:
                    Next();
                    return 0;

                default:

                    // ВОССТАНОВЛЕНИЕ
                    SkipTo(TokenType.Comma, TokenType.CloseListDelimiter, TokenType.End_operator, TokenType.ConstFloat, TokenType.ConstInt, TokenType.ConstString,
                    TokenType.ConstTrue, TokenType.ConstFalse, TokenType.Plus, TokenType.Minus);
                    return 1;
            }
        }

        private void ParseSign()
        {
            if (Current?.Type == TokenType.Plus ||
                Current?.Type == TokenType.Minus)
            {
                Next();
            }
        }
    }
}
