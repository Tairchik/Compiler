using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public class Lexer
    {
        public List<Token> Analyze(string text)
        {
            var tokens = new List<Token>();
            int pos = 0, line = 1, col = 1;

            while (pos < text.Length)
            {
                char c = text[pos];
                int startCol = col;
                int startPos = pos;

                // 1. Обработка переводов строк
                if (c == '\n' || c == '\v')
                {
                    line++;
                    col = 1;
                    pos++;
                    continue;
                }

                // 2. Обработка пробелов и табуляций
                if (c == ' ' || c == '\t' || c == '\r' || c == '\b')
                {
                    while (pos < text.Length && (text[pos] == ' ' || text[pos] == '\t' || text[pos] == '\r'))
                    {
                        pos++;
                        col++;
                    }

                    tokens.Add(new Token
                    {
                        Type = TokenType.WhiteSpace,
                        Value = "(пробел)",
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }

                // 3. Идентификаторы (id -> letter {letter | digit | _})
                if (char.IsLetter(c) || c == '_')
                {
                    string lexeme = "";
                    while (pos < text.Length && (char.IsLetterOrDigit(text[pos]) || text[pos] == '_'))
                    {
                        lexeme += text[pos];
                        col++;
                        pos++;
                    }

                    tokens.Add(new Token
                    {
                        Type = TokenType.Id,
                        Value = lexeme,
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }

                // 4. Числа (num -> digit {digit})
                if (char.IsDigit(c))
                {
                    string lexeme = "";
                    while (pos < text.Length && char.IsDigit(text[pos]))
                    {
                        lexeme += text[pos];
                        col++;
                        pos++;
                    }

                    tokens.Add(new Token
                    {
                        Type = TokenType.ConstInt,
                        Value = lexeme,
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }

                if (c == '/')
                {
                    if (pos + 1 < text.Length && text[pos + 1] == '/')
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.IntDivide,
                            Value = "//",
                            Line = line,
                            StartPos = startCol,
                            EndPos = col + 1,
                            AbsoluteIndex = startPos
                        });
                        pos += 2;
                        col += 2;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.Divide,
                            Value = "/",
                            Line = line,
                            StartPos = startCol,
                            EndPos = col,
                            AbsoluteIndex = startPos
                        });
                        pos++;
                        col++;
                    }
                    continue;
                }

                if (c == '*') 
                {
                    if (pos + 1 < text.Length && text[pos + 1] == '*')
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.Power,
                            Value = "**",
                            Line = line,
                            StartPos = startCol,
                            EndPos = col + 1,
                            AbsoluteIndex = startPos
                        });
                        pos += 2;
                        col += 2;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.Multiply,
                            Value = "*",
                            Line = line,
                            StartPos = startCol,
                            EndPos = col,
                            AbsoluteIndex = startPos
                        });
                        pos++;
                        col++;
                    }
                    continue;
                }

                // 5. Операторы и разделители
                TokenType? type = c switch
                {
                    '+' => TokenType.Plus,
                    '-' => TokenType.Minus,
                    '%' => TokenType.Mod,
                    '(' => TokenType.OpenParen,
                    ')' => TokenType.CloseParen,
                    ';' => TokenType.Semicolon,
                    _ => null
                };

                if (type != null)
                {
                    tokens.Add(new Token
                    {
                        Type = type.Value,
                        Value = c.ToString(),
                        Line = line,
                        StartPos = startCol,
                        EndPos = col,
                        AbsoluteIndex = startPos
                    });
                    col++;
                    pos++;
                    continue;
                }

                // 6. Если символ не подошёл ни под одно правило — это лексическая ошибка
                tokens.Add(new Token
                {
                    Type = TokenType.Error,
                    Value = c.ToString(),
                    Line = line,
                    StartPos = startCol,
                    EndPos = col,
                    AbsoluteIndex = startPos
                });
                pos++;
                col++;
            }
            return tokens;
        }
    }
}

