using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLangParser
{
    public class CodeParser
    {
        public List<SyntaxError> Parse(string inputCode)
        {
            ICharStream stream = CharStreams.fromString(inputCode);

            var lexer = new ArrayDefLexer(stream);
            var lexerErrorListener = new LexerErrorListener();
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(lexerErrorListener);

            var tokens = new CommonTokenStream(lexer);

            var parser = new ArrayDefParser(tokens);
            var parserErrorListener = new ParserErrorListener();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(parserErrorListener);

            var tree = parser.program();

            var allErrors = new List<SyntaxError>();
            allErrors.AddRange(lexerErrorListener.Errors);
            allErrors.AddRange(parserErrorListener.Errors);

            return allErrors;
        }
    }
}