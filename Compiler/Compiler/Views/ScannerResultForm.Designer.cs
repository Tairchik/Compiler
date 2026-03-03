namespace CompilerGUI.Views
{
    partial class ScannerResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvResult = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            SuspendLayout();

            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.BackgroundColor = Color.White; // Фон таблицы
            dgvResult.BorderStyle = BorderStyle.None;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Dock = DockStyle.Fill;
            dgvResult.GridColor = Color.Black; // Цвет сетки
            dgvResult.Location = new Point(0, 0);
            dgvResult.MultiSelect = false;
            dgvResult.Name = "dgvResult";
            dgvResult.ReadOnly = true;
            dgvResult.RowHeadersVisible = false; // Скрыть первый пустой столбец
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.Size = new Size(800, 450);
            dgvResult.TabIndex = 0;

            // Настройка стиля ячеек для соответствия фону
            dgvResult.DefaultCellStyle.BackColor = Color.White;
            dgvResult.DefaultCellStyle.ForeColor = Color.Black;
            dgvResult.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvResult.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 
            // ScannerResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvResult);
            FormBorderStyle = FormBorderStyle.FixedDialog; // Оставляет только крестик (при отключении Min/Max)
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScannerResultForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Результаты лексического анализа";
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResult;
    }
}