using CompilerGUI.HelpClass;
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
        public event Action<string>? UpdateConsoleOutPut;
        private ExceptionsCodeController exc_controller;

        public ConsoleController(ExceptionsCodeController exc_controll) 
        {
            exc_controller = exc_controll;
        }
        public void StartCode(string code)
        {
          
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
