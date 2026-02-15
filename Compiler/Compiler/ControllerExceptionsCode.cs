using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class ControllerExceptionsCode
    {
        public DataGridView exceptionGrid;
        private BindingList<ExceptionInfo> gridLines = new BindingList<ExceptionInfo>();

        public ControllerExceptionsCode(DataGridView dataGridView) 
        {
            exceptionGrid = dataGridView;
            exceptionGrid.DataSource = gridLines;
            gridLines.ListChanged += UpdateNumbers;
        }

        private void UpdateNumbers(object? sender, ListChangedEventArgs e) 
        {
            for (int i = 1; i <= gridLines.Count; i++) 
            {
                gridLines[i - 1].Number = i;
            }
        }

        public void TextCodeChanged(string textCode, FileClass fileClass) 
        {
            Clear(fileClass.FileName);
            // Анализируем код программы (Анализ будет со стороны другого контроллера -> консольного, который и будет общаться с ядром)
            ExceptionInfo exception = new ExceptionInfo();

            List<string> textCodeList = new List<string>(textCode.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
            exception.Line = textCodeList.Count;
            exception.ExceptionMessage = $"Ошибка {textCodeList.Count}";
            exception.FileName = fileClass.FileName;
            exception.Column = 0;

            if (string.IsNullOrEmpty(fileClass.FilePath)) exception.FilePath = $"..{exception.FileName}";
            else exception.FilePath = fileClass.FilePath;
            AddExseptionInGrid(exception);
        }

        public void PageCodeChanged(string textCode, FileClass fileClass)
        {
            foreach (var ex in gridLines) 
            {
                if (ex.FileName == fileClass.FileName) return;
            }

            // Анализируем код программы
            ExceptionInfo exception = new ExceptionInfo();

            List<string> textCodeList = new List<string>(textCode.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
            exception.Line = textCodeList.Count;
            exception.ExceptionMessage = $"Ошибка {textCodeList.Count}";
            exception.FileName = fileClass.FileName;
            exception.Column = 0;


            if (string.IsNullOrEmpty(fileClass.FilePath)) exception.FilePath = $"..{exception.FileName}";
            else exception.FilePath = fileClass.FilePath;
            AddExseptionInGrid(exception);
        }

        public void AddExseptionInGrid(ExceptionInfo exception) 
        {
            gridLines.Add(exception);
        }

        public void RemoveExseption(int index)
        {
            if (index < gridLines.Count - 1)
            gridLines.RemoveAt(index);
        }

        public void Clear()
        {
            gridLines.Clear();
        }

        public void Clear(string FileName)
        {
            for (int i = gridLines.Count - 1; i >= 0; i--)
            {
                if (gridLines[i].FileName == FileName)
                {
                    gridLines.RemoveAt(i);
                }
            }
        }
    }
}
