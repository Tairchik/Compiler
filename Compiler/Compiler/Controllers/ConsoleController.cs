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
        public event Action<string>? ChangeStatusRun;
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
            ChangeStatusRun?.Invoke(LocalizationService.Get("Assembling"));
            string code = textBoxCode.Text;
            string info = "ExceptionMessage";
            ChangeStatusRun?.Invoke(LocalizationService.Get("RunStatus"));
            if (!string.IsNullOrEmpty(info))
            FindException?.Invoke(info);
            UpdateTextConsole(info);
            ChangeStatusRun?.Invoke(LocalizationService.Get("Ready"));
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
