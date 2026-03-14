using CompilerGUI.HelpClass;
using CompilerGUI.Scaner;
using System;
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
        private ParserService parser_bison = new ParserService();
        private ExceptionsCodeController exc_controller;

        public ConsoleController(ExceptionsCodeController exc_controll) 
        {
            exc_controller = exc_controll;
        }
        public void StartCode(string code)
        {
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Analyze(code);
            ScanCompleted?.Invoke(tokens);

            var res = parser_bison.Parse(code);
            if (res.IsSuccess) 
            {
                ChangeStatusRun?.Invoke(LocalizationService.Get("Ready"));

                exc_controller.ClearBeforeAdd();
                UpdateTextConsole(res.Message);
            }
            else 
            {
                ChangeStatusRun?.Invoke(LocalizationService.Get("Error"));
                UpdateTextConsole("Ошибка");
                exc_controller.ClearBeforeAdd();
                int i = 0;
                var str_res = res.Message.Split('\r');

                foreach (var err in str_res) 
                {
                    exc_controller.AddExceptionToGrid(err, res.line[i]);
                    i++;
                }
            }
            /*
            ChangeStatusRun?.Invoke(LocalizationService.Get("Assembling"));
            string info = "ExceptionMessage";
            ChangeStatusRun?.Invoke(LocalizationService.Get("RunStatus"));
            if (!string.IsNullOrEmpty(info))
            FindException?.Invoke(info);
            UpdateTextConsole(info);
            ChangeStatusRun?.Invoke(LocalizationService.Get("Ready"));
            */
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
