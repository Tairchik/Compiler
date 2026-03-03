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
        private BindingList<Token> data = new BindingList<Token>();
        public event Action<Token>? RowSelected;
        public event Action? CloseForm;


        public ScannerResultForm(List<Token> tokens)
        {
            InitializeComponent();
            SetupColumns();
            this.FormClosing += ScannerResultForm_FormClosing; ;
            dgvResult.CellDoubleClick += DgvResult_CellDoubleClick;
            LoadData(tokens);
        }

        private void ScannerResultForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke();
        }
        private void DgvResult_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            RowSelected?.Invoke(data[e.RowIndex]);
        }
        public void UpdateGrid(List<Token> tokens) 
        {
            dgvResult.Rows.Clear();
            LoadData(tokens);
        }
        private void SetupColumns()
        {
            dgvResult.Columns.Clear();

            DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn lexemeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn locationColumn = new DataGridViewTextBoxColumn();

            codeColumn.DataPropertyName = "Code";
            codeColumn.HeaderText = "Условный код";
            codeColumn.Name = "codeColumn";
            codeColumn.ReadOnly = true;

            typeColumn.DataPropertyName = "TypeName";
            typeColumn.HeaderText = "Тип лексемы";
            typeColumn.Name = "typeColumn";
            typeColumn.ReadOnly = true;

            lexemeColumn.DataPropertyName = "Value";
            lexemeColumn.HeaderText = "Лексема";
            lexemeColumn.Name = "lexemeColumn";
            lexemeColumn.ReadOnly = true;

            locationColumn.DataPropertyName = "Location";
            locationColumn.HeaderText = "Местоположение";
            locationColumn.Name = "locationColumn";
            locationColumn.ReadOnly = true;

            dgvResult.Columns.AddRange(new DataGridViewColumn[] { codeColumn, typeColumn, lexemeColumn, locationColumn });

            dgvResult.Columns["codeColumn"].FillWeight = 50;
            dgvResult.DataSource = data;

        }

        private void LoadData(List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                data.Add(token);
                if (token.Type == TokenType.Error)
                {
                    dgvResult.Rows[data.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
