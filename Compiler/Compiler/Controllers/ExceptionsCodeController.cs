using CompilerGUI.HelpClass;
using CompilerGUI.Scaner;

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
        public DataGridView exceptionSyntaxGrid;
        public DataGridView lexerGrid;
        public BindingList<ExceptionInfo> gridLines = new BindingList<ExceptionInfo>();
        public BindingList<Token> gridLinesLexer = new BindingList<Token>();

        public event Func<FileClass> GetFileClass;

        public ExceptionsCodeController(DataGridView dataGridViewSyntax, DataGridView dataGridViewLexer) 
        {
            exceptionSyntaxGrid = dataGridViewSyntax;
            exceptionSyntaxGrid.DataSource = gridLines;
            gridLines.ListChanged += UpdateNumbers;
            lexerGrid = dataGridViewLexer;
            lexerGrid.DataSource = gridLinesLexer;

            lexerGrid.CellFormatting += LexerGrid_CellFormatting;
        }
        private void LexerGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridLinesLexer.Count)
            {
                var token = gridLinesLexer[e.RowIndex];
                if (token.Type == TokenType.Error)
                {
                    lexerGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    lexerGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
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
            ClearAll();
        }

        public void AddExceptionSyntaxToGrid(string errorMessage, string value, int line, int position, int startPos, int endPos)
        {
            ExceptionInfo exception = new ExceptionInfo();
            exception.Location = $"Строка: {line}, позиция: {startPos}-{endPos}";
            exception.StartPos = startPos;
            exception.EndPos = endPos;
            exception.ExceptionMessage = errorMessage;
            exception.Column = position;
            exception.InvalidText = value;
            gridLines.Add(exception);
        }
       
        public void AddLexerToGrid(Token token)
        {
            gridLinesLexer.Add(token);
        }

        private void ClearAll()
        {
            gridLines.Clear();
            gridLinesLexer.Clear();
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
