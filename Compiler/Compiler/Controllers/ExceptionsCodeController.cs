using CompilerGUI.HelpClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Controllers
{
    public class ExceptionsCodeController
    {
        public DataGridView exceptionGrid;
        public BindingList<ExceptionInfo> gridLines = new BindingList<ExceptionInfo>();
        public event Func<FileClass> GetFileClass;

        public ExceptionsCodeController(DataGridView dataGridView) 
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

        public void ClearBeforeAdd() 
        {
            FileClass fc = GetFileClass.Invoke();
            Clear(fc.FileName, fc.FilePath);
        }


        public void AddExceptionToGrid(string errorMessage, int line, int position, int startPos, int endPos)
        {
            FileClass fc = GetFileClass.Invoke();

            ExceptionInfo exception = new ExceptionInfo();
            exception.Location = $"Строка: {line}, позиция: {startPos}-{endPos}";
            exception.StartPos = startPos;
            exception.EndPos = endPos;
            exception.ExceptionMessage = errorMessage;
            exception.FileName = fc.FileName;
            exception.Column = position;

            if (string.IsNullOrEmpty(fc.FilePath)) exception.FilePath = $"..{exception.FileName}";
            else exception.FilePath = fc.FilePath;
            AddLineGrid(exception);
        }

        public void AddLineGrid(ExceptionInfo exception) 
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

        public void Clear(string FileName, string FilePath = "")
        {
            if (string.IsNullOrEmpty(FilePath)) 
            {
                for (int i = gridLines.Count - 1; i >= 0; i--)
                {
                    if (gridLines[i].FileName == FileName)
                    {
                        gridLines.RemoveAt(i);
                    }
                }
            }
            else 
            {
                for (int i = gridLines.Count - 1; i >= 0; i--)
                {
                    if (gridLines[i].FilePath == FilePath)
                    {
                        gridLines.RemoveAt(i);
                    }
                }
            }
        }
    }
}
