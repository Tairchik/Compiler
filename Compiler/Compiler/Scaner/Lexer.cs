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

                if (c == '\n')
                {
                    line++;
                    col = 1;
                    pos++;
                    continue;
                }
                if (c == ' ' || c == '\b' || c == '\r')
                {
                    string spaces = "";
                    while (pos < text.Length && (text[pos] == ' ' || text[pos] == '\t' || text[pos] == '\r'))
                    {
                        spaces += text[pos];
                        pos++; col++;
                    }

                    tokens.Add(new Token
                    {
                        Type = TokenType.WhiteSpace,
                        Value = spaces,
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }
                if (char.IsLetter(c) || c == '_')
                {
                    string lexeme = "";
                    while (pos < text.Length && (char.IsLetterOrDigit(text[pos]) || text[pos] == '_'))
                    {
                        lexeme += text[pos];
                        col++; pos++;
                    }
                    TokenType type;
                    switch (lexeme) 
                    {
                        case "True":
                            type = TokenType.ConstTrue; 
                            break;
                        case "False":
                            type = TokenType.ConstFalse; 
                            break;
                        default:
                            type = TokenType.Id;
                            break;
                    }
                    tokens.Add(new Token 
                    { 
                        Type = type, 
                        Value = lexeme, 
                        Line = line, 
                        StartPos = startCol, 
                        EndPos = col - 1, 
                        AbsoluteIndex = startPos
                    });
                    continue;
                }
                if (c == '=' || c == '+' || c == '-' || c == '[' || c == ']' || c == ',')
                {
                    col++; pos++;
                    TokenType type = TokenType.Error;
                    switch (c)
                    {
                        case '=':
                            type = TokenType.Equal;
                            break;
                        case '+':
                            type = TokenType.Plus;
                            break;
                        case '-':
                            type = TokenType.Minus;
                            break;
                        case '[':
                            type = TokenType.CloseListDelimiter;
                            break;
                        case ']':
                            type = TokenType.OpenListDelimiter;
                            break;
                        case ',':
                            type = TokenType.Comma;
                            break;
                        case ';':
                            type = TokenType.End_operator; 
                            break;
                    }
                    tokens.Add(new Token
                    {
                        Type = type,
                        Value = char.ToString(c),
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }
                if (c == '\'')
                {
                    string lexeme = "";
                    bool lastIsQuote = false;
                    do
                    {
                        lexeme += text[pos];
                        col++; pos++;
                    }
                    while (pos < text.Length && text[pos] != '\'');

                    if (text[pos] == '\'')
                    {
                        lexeme += text[pos];
                        col++; pos++;

                        tokens.Add(new Token
                        {
                            Type = TokenType.ConstString,
                            Value = "(пробел)",
                            Line = line,
                            StartPos = startCol,
                            EndPos = col - 1,
                            AbsoluteIndex = startPos
                        });
                        continue;
                    }

                    tokens.Add(new Token
                    {
                        Type = TokenType.Error,
                        Value = lexeme,
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;
                }
                if (c == ';')
                {
                    tokens.Add(new Token
                    {
                        Type = TokenType.End_operator,
                        Value = ";",
                        Line = line,
                        StartPos = startCol,
                        EndPos = col,
                        AbsoluteIndex = startPos
                    });
                    col++; pos++;
                    continue;
                }
                if (char.IsDigit(c)) 
                {
                    string lexeme = "";
                    while (pos < text.Length && char.IsDigit(text[pos]))
                    {
                        lexeme += text[pos];
                        col++; pos++;
                    }

                    TokenType tokenType = TokenType.Error;

                    if (text[pos] == '.') 
                    {
                        tokenType = TokenType.ConstFloat;
                        do
                        {
                            lexeme += text[pos];
                            col++; pos++;
                        }
                        while (pos < text.Length && char.IsDigit(text[pos]));
                    }
                    else 
                    {
                        tokenType = TokenType.ConstInt;
                    }

                    tokens.Add(new Token
                    {
                        Type = tokenType,
                        Value = lexeme,
                        Line = line,
                        StartPos = startCol,
                        EndPos = col - 1,
                        AbsoluteIndex = startPos
                    });
                    continue;

                }
                tokens.Add(new Token 
                {
                    Type = TokenType.Error, 
                    Value = c.ToString(), 
                    Line = line, 
                    StartPos = startCol, 
                    EndPos = col, 
                    AbsoluteIndex = startPos 
                });
                pos++; col++;
            }
            return tokens;
        }
    }
}
