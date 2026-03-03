using CompilerGUI.Scaner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerGUI.Views
{
    public partial class ScannerResultForm : Form
    {
        public ScannerResultForm(List<Token> tokens)
        {
            InitializeComponent();
            SetupColumns();
            LoadData(tokens);
        }

        private void SetupColumns()
        {
            dgvResult.Columns.Clear();

            dgvResult.Columns.Add("Code", "Условный код");
            dgvResult.Columns.Add("Type", "Тип лексемы");
            dgvResult.Columns.Add("Lexeme", "Лексема");
            dgvResult.Columns.Add("Location", "Местоположение");

            // Настройка выравнивания для числового кода
            dgvResult.Columns["Code"].FillWeight = 50;
        }

        private void LoadData(List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                string location = $"Стр: {token.Line}, Поз: {token.StartPos}-{token.EndPos}";

                int rowIndex = dgvResult.Rows.Add(
                    token.Code,
                    token.TypeName,
                    token.Value,
                    location
                );

                // Если это ошибка, подсветим строку (опционально, но полезно)
                if (token.Type == TokenType.Error)
                {
                    dgvResult.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
