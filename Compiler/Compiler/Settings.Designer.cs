namespace CompilerGUI
{
    partial class Settings
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
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonOk = new Button();
            buttonCancel = new Button();
            languageComboBox = new ComboBox();
            Languagelabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.74772F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.8571434F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.079155F));
            tableLayoutPanel1.Controls.Add(buttonOk, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonCancel, 2, 1);
            tableLayoutPanel1.Controls.Add(languageComboBox, 1, 0);
            tableLayoutPanel1.Controls.Add(Languagelabel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70.19231F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 29.8076916F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(369, 144);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Right;
            buttonOk.Location = new Point(178, 97);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(68, 23);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Left;
            buttonCancel.Location = new Point(252, 97);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(81, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            // 
            // languageComboBox
            // 
            languageComboBox.Anchor = AnchorStyles.Left;
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.Location = new Point(111, 45);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(135, 23);
            languageComboBox.TabIndex = 1;
            // 
            // Languagelabel
            // 
            Languagelabel.Anchor = AnchorStyles.Right;
            Languagelabel.AutoSize = true;
            Languagelabel.Location = new Point(68, 49);
            Languagelabel.Name = "Languagelabel";
            Languagelabel.Size = new Size(37, 15);
            Languagelabel.TabIndex = 0;
            Languagelabel.Text = "Язык:";
            // 
            // Settings
            // 
            ClientSize = new Size(369, 144);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonOk;
        private Button buttonCancel;
        private ComboBox languageComboBox;
        private Label Languagelabel;
    }
}