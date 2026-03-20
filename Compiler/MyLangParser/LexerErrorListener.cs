using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLangParser
{
    public class LexerErrorListener : IAntlrErrorListener<int>
    {
        public List<SyntaxError> Errors { get; } = new List<SyntaxError>();

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Lexer lexer = (Lexer)recognizer;

            var error = new SyntaxError(
                line: line,
                start_pos: charPositionInLine,
                end_pos: charPositionInLine + 1, // Ошибка лексера обычно на 1 конкретном символе
                abs_index: lexer.CharIndex,
                message: msg,
                value: ((char)offendingSymbol).ToString()
            );

            Errors.Add(error);
        }
    }
}
