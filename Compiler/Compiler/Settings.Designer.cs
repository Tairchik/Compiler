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
            Languagelabel = new Label();
            languageComboBox = new ComboBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(languageComboBox, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonOk, 1, 3);
            tableLayoutPanel1.Controls.Add(buttonCancel, 2, 3);
            tableLayoutPanel1.Controls.Add(Languagelabel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(420, 220);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Languagelabel
            // 
            Languagelabel.Anchor = AnchorStyles.Right;
            Languagelabel.AutoSize = true;
            Languagelabel.Location = new Point(94, 71);
            Languagelabel.Name = "Languagelabel";
            Languagelabel.Size = new Size(37, 15);
            Languagelabel.TabIndex = 0;
            Languagelabel.Text = "Язык:";
            // 
            // languageComboBox
            // 
            languageComboBox.Anchor = AnchorStyles.Left;
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.Location = new Point(137, 67);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(121, 23);
            languageComboBox.TabIndex = 1;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Right;
            buttonOk.Location = new Point(183, 170);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(100, 23);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Left;
            buttonCancel.Location = new Point(289, 170);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            // 
            // Settings
            // 
            ClientSize = new Size(420, 220);
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
        private ComboBox languageComboBox;
        private Label Languagelabel;
        private Button buttonOk;
        private Button buttonCancel;
    }
}