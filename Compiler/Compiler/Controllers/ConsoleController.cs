using CompilerGUI.HelpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Controllers
{
    public class ConsoleController
    {
        private RichTextBox? textBoxCode;
        public event Action<string>? FindException;

        public ConsoleController() 
        {
            textBoxCode = new RichTextBox();
        }

        public void InitCodeTextBox(TabPage tabPage)
        {
            if (tabPage != null)
            textBoxCode = (RichTextBox) tabPage.Controls.Find("RichTextBoxOut", true)[0];
        }
        public void StartCode()
        {
            if (textBoxCode == null) return;
            // Компилируем, анализируем и тд
            string code = textBoxCode.Text;
            string info = "ExceptionMessage";
            if (!string.IsNullOrEmpty(info))
            FindException?.Invoke(info);
            UpdateTextConsole(info);
        }
        
        // Проверка в момент написания на ошибки
        public List<ExceptionInfo> AnalysisSyntax()
        {
            return new List<ExceptionInfo>();
        }

        private void UpdateTextConsole(string text) 
        {
            textBoxCode.Clear();
            List<string> lines = new List<string>(text.Split("\n"));

            foreach (string line in lines) 
            {
                textBoxCode.AppendText($"> {line}");
            }
        }
    }
}
