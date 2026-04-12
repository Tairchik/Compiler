using CompilerGUI.HelpClass;
using CompilerGUI.Scaner;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Controllers
{
    public class ConsoleController
    {
        public event Action<string>? FindException;
        public event Action<string>? ChangeStatusRun;
        public event Action<List<Token>>? ScanCompleted;
        public event Action<string>? UpdateConsoleOutPut;
        private ExceptionsCodeController exc_controller;

        public ConsoleController(ExceptionsCodeController exc_controll) 
        {
            exc_controller = exc_controll;
        }
        public void StartCode(string code)
        {
            if (code == null) return;
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Analyze(code);
            exc_controller.ClearBeforeAdd();

            if (tokens.Count != 0) 
            {
                foreach (var tk in tokens)
                {
                    exc_controller.AddLexerToGrid(tk);
                }
            }

            Parser parser = new Parser();

            var pars = parser.Parse(tokens);
            if (pars == null || pars.Count == 0) 
            {
                UpdateTextConsole("Успешно");
            }
            else 
            {
                ChangeStatusRun?.Invoke(LocalizationService.Get("Error"));
                UpdateTextConsole($"Ошибка. Число ошибок: {pars.Count}");
                int i = 0;
                foreach (var err in pars)
                {
                    exc_controller.AddExceptionSyntaxToGrid(err.Message, err.Value, err.Line, err.AbsoluteIndex, err.StartPos, err.EndPos);
                    i++;
                }
            }
        }

        public List<ExceptionInfo> AnalysisSyntax()
        {
            return new List<ExceptionInfo>();
        }

        private void UpdateTextConsole(string errors) 
        {
            UpdateConsoleOutPut?.Invoke(errors);
        }
    }
}
