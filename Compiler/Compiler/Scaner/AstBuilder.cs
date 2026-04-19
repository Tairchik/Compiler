using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace CompilerGUI.Scaner
{
    public class AstBuilder
    {
        private List<Token> _tokens;
        private int _pos = 0;
        private List<SyntaxError> _errors = new();
        private HashSet<string> _symbolTable = new();
        private Token? Current => _pos < _tokens.Count ? _tokens[_pos] : null;

        public (ProgramNode Root, List<SyntaxError> Errors) Build(List<Token> tokens, List<SyntaxError>? syntaxErrors)
        {
            _tokens = tokens.Where(t => t.Type != TokenType.WhiteSpace).ToList();
            _pos = 0;
            _errors.Clear();
            _symbolTable.Clear();

            var root = new ProgramNode();

            while (_pos < _tokens.Count)
            {
                if (Current == null) break;

                if (Current.Type != TokenType.Id)
                {
                    _pos++;
                    continue;
                }

                if (IsLineCorrupted(Current.Line, syntaxErrors))
                {
                    SkipStatement();
                    continue;
                }

                int errorsCountBefore = _errors.Count;

                var node = ParseAssignment();

                if (node != null && _errors.Count == errorsCountBefore)
                {
                    _symbolTable.Add(node.Id);
                    root.Nodes.Add(node);
                }
            }

            return (root, _errors);
        }

        private bool IsLineCorrupted(int line, List<SyntaxError>? syntaxErrors)
        {
            if (syntaxErrors == null) return false;
            return syntaxErrors.Any(e => e.Line == line && !e.Message.Contains(";"));
        }

        private void SkipStatement()
        {
            while (Current != null && Current.Type != TokenType.End_operator)
                _pos++;
            if (Current?.Type == TokenType.End_operator)
                _pos++;
        }

        private ListInitNode? ParseAssignment()
        {
            if (Current == null) return null;

            var node = new ListInitNode();
            Token idToken = Current;

            if (_symbolTable.Contains(idToken.Value))
            {
                _errors.Add(new SyntaxError(idToken.Line, idToken.StartPos, idToken.EndPos,
                    idToken.AbsoluteIndex, $"Идентификатор '{idToken.Value}' уже объявлен ранее", idToken.Value));
                SkipStatement();
                return null;
            }

            node.Id = idToken.Value;
            _pos++;

            if (Current?.Type != TokenType.Equal) { SkipStatement(); return null; }
            _pos++;
            if (Current?.Type != TokenType.OpenListDelimiter) { SkipStatement(); return null; }
            _pos++;

            while (Current != null && Current.Type != TokenType.CloseListDelimiter && Current.Type != TokenType.End_operator)
            {
                if (IsLiteral(Current.Type) || Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
                {
                    var literal = ParseLiteral();
                    if (literal == null) return null; 
                    node.Elements.Add(literal);
                }
                else if (Current.Type == TokenType.Comma)
                {
                    _pos++;
                }
                else
                {
                    SkipStatement();
                    return null;
                }
            }

            if (Current?.Type != TokenType.CloseListDelimiter) { SkipStatement(); return null; }
            _pos++;

            if (Current?.Type != TokenType.End_operator) return null;
            _pos++;

            return node;
        }

        private LiteralNode? ParseLiteral()
        {
            string sign = "";
            if (Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
            {
                sign = Current.Value;
                _pos++;
            }

            if (Current == null) return null;
            Token valToken = Current;

            if (valToken.Type == TokenType.ConstFloat)
            {
                if (double.TryParse(sign + valToken.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double res))
                {
                    if (double.IsInfinity(res))
                    {
                        _errors.Add(new SyntaxError(valToken.Line, valToken.StartPos, valToken.EndPos,
                            valToken.AbsoluteIndex, "Значение float выходит за границы диапазона", valToken.Value));
                        _pos++;
                        return null;
                    }
                }
            }

            var node = new LiteralNode { Value = sign + valToken.Value, Type = valToken.TypeName };
            _pos++;
            return node;
        }

        private bool IsLiteral(TokenType type) =>
            type == TokenType.ConstInt || type == TokenType.ConstFloat ||
            type == TokenType.ConstString || type == TokenType.ConstTrue || type == TokenType.ConstFalse;
    }
}