using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class ControllerConsole
    {
        private RichTextBox textBoxCode;
        public event Action<ExceptionInfo>? FindException;

        public ControllerConsole() 
        {
            textBoxCode = new RichTextBox();
        }

        public void InitCodeTextBox(RichTextBox textBoxCode) 
        {
            this.textBoxCode = textBoxCode;
        }
        public void StartCode() 
        {
            // Компилируем, анализируем и тд
            string code = textBoxCode.Text;
            ExceptionInfo info = new ExceptionInfo();
            FindException?.Invoke(info);
        }
        
        // Проверка в момент написания
        public List<ExceptionInfo> AnalysisSyntax()
        {
            return new List<ExceptionInfo>();
        }

    }
}
