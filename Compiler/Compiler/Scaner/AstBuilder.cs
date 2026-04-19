using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (IsCurrentPositionCorrupted(syntaxErrors))
                {
                    SkipToRecoveryPoint(syntaxErrors);
                    continue;
                }

                if (Current?.Type == TokenType.Id)
                {
                    var node = ParseAssignment();
                    if (node != null) root.Nodes.Add(node);
                }
                else
                {
                    _pos++;
                }
            }

            return (root, _errors);
        }

        private bool IsCurrentPositionCorrupted(List<SyntaxError>? syntaxErrors)
        {
            if (syntaxErrors == null || syntaxErrors.Count == 0 || Current == null) return false;

            return syntaxErrors.Any(e => e.Line == Current.Line && Current.AbsoluteIndex <= e.AbsoluteIndex);
        }

        private void SkipToRecoveryPoint(List<SyntaxError>? syntaxErrors)
        {
            if (Current == null) return;

            var error = syntaxErrors?.FirstOrDefault(e => e.Line == Current.Line);
            bool isMissingSemicolon = error != null && (error.Message.Contains(";") || error.Message.Contains("конец оператора"));

            while (_pos < _tokens.Count)
            {
                if (Current.Type == TokenType.End_operator)
                {
                    _pos++; 
                    break;
                }

                if (isMissingSemicolon && Current.Type == TokenType.Id && _pos > 0)
                {
                    break;
                }

                _pos++;
            }
        }

        private ListInitNode? ParseAssignment()
        {
            var node = new ListInitNode();
            Token idToken = Current;

            if (_symbolTable.Contains(idToken.Value))
            {
                _errors.Add(new SyntaxError(idToken.Line, idToken.StartPos, 
                    idToken.EndPos, idToken.AbsoluteIndex, 
                    $"Идентификатор '{idToken.Value}' уже объявлен ранее (линия {idToken.Line})", idToken.Value));
                while (Current != null && Current.Type != TokenType.End_operator) _pos++;
                return null;
            }
            else
            {
                _symbolTable.Add(idToken.Value);
            }
            node.Id = idToken.Value;
            _pos++;

            while (Current != null && Current.Type != TokenType.OpenListDelimiter && Current.Type != TokenType.End_operator)
                _pos++;

            if (Current?.Type == TokenType.OpenListDelimiter)
            {
                _pos++; 
                while (Current != null && Current.Type != TokenType.CloseListDelimiter && Current.Type != TokenType.End_operator)
                {
                    if (IsLiteral(Current.Type) || Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
                    {
                        var literal = ParseLiteral();
                        if (literal != null) node.Elements.Add(literal);
                        else
                        {
                            _symbolTable.Remove(idToken.Value);
                            while (Current != null && Current.Type != TokenType.End_operator) _pos++;
                            return null;
                        }
                    }
                    else _pos++;
                }
            }

            while (Current != null && Current.Type != TokenType.End_operator) _pos++;
            if (Current?.Type == TokenType.End_operator) _pos++;

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
            var node = new LiteralNode { Value = sign + valToken.Value };

            if (valToken.Type == TokenType.ConstFloat)
            {
                node.Type = "float";
                if (double.TryParse(valToken.Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double res))
                {
                    if (double.IsInfinity(res))
                        _errors.Add(new SyntaxError(valToken.Line, valToken.StartPos,
                        valToken.EndPos, valToken.AbsoluteIndex,
                        "Значение float выходит за границы допустимого диапазона", valToken.Value));
                    return null;
                }
            }
            else node.Type = valToken.TypeName;

            _pos++;
            return node;
        }
        private bool IsLiteral(TokenType type) =>
            type == TokenType.ConstInt || type == TokenType.ConstFloat ||
            type == TokenType.ConstString || type == TokenType.ConstTrue || type == TokenType.ConstFalse;
    }
}
