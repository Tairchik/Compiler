using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLangParser
{
    public class ParserErrorListener : BaseErrorListener
    {
        public List<SyntaxError> Errors { get; } = new List<SyntaxError>();

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            int startPos = offendingSymbol?.StartIndex ?? 0;
            int endPos = offendingSymbol?.StopIndex ?? 0;
            int length = (endPos - startPos) >= 0 ? (endPos - startPos + 1) : 1;
            string value = offendingSymbol?.Text ?? "";

            var error = new SyntaxError(
                line: line,
                start_pos: charPositionInLine,
                end_pos: charPositionInLine + length,
                abs_index: startPos,
                message: msg,
                value: value
            );

            Errors.Add(error);
        }
    }
}

