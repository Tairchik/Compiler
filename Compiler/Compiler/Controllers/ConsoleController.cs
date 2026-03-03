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
        public ConsoleController() 
        {

        }
        public void StartCode(string code)
        {
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Analyze(code);
            ScanCompleted?.Invoke(tokens);
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

        private void UpdateTextConsole(string text) 
        {
            
        }
    }
}
