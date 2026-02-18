namespace CompilerGUI
{
    partial class CompilerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip = new MenuStrip();
            FileTS = new ToolStripMenuItem();
            createMI = new ToolStripMenuItem();
            openMI = new ToolStripMenuItem();
            SaveMI = new ToolStripMenuItem();
            saveUsMI = new ToolStripMenuItem();
            exitMI = new ToolStripMenuItem();
            Edit = new ToolStripMenuItem();
            undoMI = new ToolStripMenuItem();
            redoMI = new ToolStripMenuItem();
            cutMI = new ToolStripMenuItem();
            copyMI = new ToolStripMenuItem();
            insertMI = new ToolStripMenuItem();
            deleteMI = new ToolStripMenuItem();
            selectAllMI = new ToolStripMenuItem();
            textMI = new ToolStripMenuItem();
            taskAimIM = new ToolStripMenuItem();
            grammaticMI = new ToolStripMenuItem();
            typegrammaticMI = new ToolStripMenuItem();
            methodAnalysisMI = new ToolStripMenuItem();
            testExampleMI = new ToolStripMenuItem();
            bibliographyMI = new ToolStripMenuItem();
            gitURLMI = new ToolStripMenuItem();
            Run = new ToolStripMenuItem();
            aboutMI = new ToolStripMenuItem();
            SettingsMI = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            undoTSB = new ToolStripButton();
            redoTSB = new ToolStripButton();
            createTSB = new ToolStripButton();
            saveTSB = new ToolStripButton();
            saveUsTSB = new ToolStripButton();
            copyTSB = new ToolStripButton();
            cutTSB = new ToolStripButton();
            selectAllTSB = new ToolStripButton();
            deleteTabTSB = new ToolStripButton();
            mainPanel = new SplitContainer();
            dataGridView = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            FilePathColumn = new DataGridViewTextBoxColumn();
            LineColumn = new DataGridViewTextBoxColumn();
            ColumnColumn = new DataGridViewTextBoxColumn();
            MessageColumn = new DataGridViewTextBoxColumn();
            menuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainPanel).BeginInit();
            mainPanel.Panel2.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileTS, Edit, textMI, Run, aboutMI, SettingsMI });
            menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1073, 23);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // FileTS
            // 
            FileTS.DropDownItems.AddRange(new ToolStripItem[] { createMI, openMI, SaveMI, saveUsMI, exitMI });
            FileTS.Name = "FileTS";
            FileTS.Size = new Size(48, 19);
            FileTS.Text = "Файл";
            // 
            // createMI
            // 
            createMI.Name = "createMI";
            createMI.ShortcutKeyDisplayString = "Ctrl+N";
            createMI.Size = new Size(225, 22);
            createMI.Text = "Создать";
            createMI.Click += createFile_Click;
            // 
            // openMI
            // 
            openMI.Name = "openMI";
            openMI.ShortcutKeyDisplayString = "Ctrl+O";
            openMI.Size = new Size(225, 22);
            openMI.Text = "Открыть";
            openMI.Click += openFile_Click;
            // 
            // SaveMI
            // 
            SaveMI.Name = "SaveMI";
            SaveMI.ShortcutKeyDisplayString = "Ctrl+S";
            SaveMI.Size = new Size(225, 22);
            SaveMI.Text = "Сохранить";
            SaveMI.Click += saveFile_Click;
            // 
            // saveUsMI
            // 
            saveUsMI.Name = "saveUsMI";
            saveUsMI.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            saveUsMI.Size = new Size(225, 22);
            saveUsMI.Text = "Сохранить как";
            saveUsMI.Click += saveUsFile_Click;
            // 
            // exitMI
            // 
            exitMI.Name = "exitMI";
            exitMI.ShortcutKeyDisplayString = "Alt+F4";
            exitMI.Size = new Size(225, 22);
            exitMI.Text = "Выход";
            exitMI.Click += exit_Click;
            // 
            // Edit
            // 
            Edit.DropDownItems.AddRange(new ToolStripItem[] { undoMI, redoMI, cutMI, copyMI, insertMI, deleteMI, selectAllMI });
            Edit.Name = "Edit";
            Edit.Size = new Size(59, 19);
            Edit.Text = "Правка";
            // 
            // undoMI
            // 
            undoMI.Name = "undoMI";
            undoMI.ShortcutKeyDisplayString = "Ctrl+Z";
            undoMI.Size = new Size(190, 22);
            undoMI.Text = "Отменить";
            undoMI.Click += undo_Click;
            // 
            // redoMI
            // 
            redoMI.Name = "redoMI";
            redoMI.ShortcutKeyDisplayString = "Ctrl+Y";
            redoMI.Size = new Size(190, 22);
            redoMI.Text = "Вернуть";
            redoMI.Click += redo_Click;
            // 
            // cutMI
            // 
            cutMI.Name = "cutMI";
            cutMI.ShortcutKeyDisplayString = "Ctrl+X";
            cutMI.Size = new Size(190, 22);
            cutMI.Text = "Вырезать";
            cutMI.Click += cut_Click;
            // 
            // copyMI
            // 
            copyMI.Name = "copyMI";
            copyMI.ShortcutKeyDisplayString = "Ctrl+C";
            copyMI.Size = new Size(190, 22);
            copyMI.Text = "Копировать";
            copyMI.Click += copy_Click;
            // 
            // insertMI
            // 
            insertMI.Name = "insertMI";
            insertMI.ShortcutKeyDisplayString = "Ctrl+V";
            insertMI.Size = new Size(190, 22);
            insertMI.Text = "Вставить";
            insertMI.Click += insert_Click;
            // 
            // deleteMI
            // 
            deleteMI.Name = "deleteMI";
            deleteMI.ShortcutKeyDisplayString = "Del";
            deleteMI.Size = new Size(190, 22);
            deleteMI.Text = "Удалить";
            deleteMI.Click += deleteText_Click;
            // 
            // selectAllMI
            // 
            selectAllMI.Name = "selectAllMI";
            selectAllMI.ShortcutKeyDisplayString = "Ctrl+A";
            selectAllMI.Size = new Size(190, 22);
            selectAllMI.Text = "Выделить все";
            selectAllMI.Click += selectAll_Click;
            // 
            // textMI
            // 
            textMI.BackgroundImageLayout = ImageLayout.Stretch;
            textMI.DropDownItems.AddRange(new ToolStripItem[] { taskAimIM, grammaticMI, typegrammaticMI, methodAnalysisMI, testExampleMI, bibliographyMI, gitURLMI });
            textMI.Name = "textMI";
            textMI.Size = new Size(49, 19);
            textMI.Text = "Текст";
            textMI.Visible = false;
            // 
            // taskAimIM
            // 
            taskAimIM.Name = "taskAimIM";
            taskAimIM.Size = new Size(231, 22);
            taskAimIM.Text = "Постановка задачи";
            // 
            // grammaticMI
            // 
            grammaticMI.Name = "grammaticMI";
            grammaticMI.Size = new Size(231, 22);
            grammaticMI.Text = "Грамматика";
            // 
            // typegrammaticMI
            // 
            typegrammaticMI.Name = "typegrammaticMI";
            typegrammaticMI.Size = new Size(231, 22);
            typegrammaticMI.Text = "Классификация грамматики";
            // 
            // methodAnalysisMI
            // 
            methodAnalysisMI.Name = "methodAnalysisMI";
            methodAnalysisMI.Size = new Size(231, 22);
            methodAnalysisMI.Text = "Метод анализа";
            // 
            // testExampleMI
            // 
            testExampleMI.Name = "testExampleMI";
            testExampleMI.Size = new Size(231, 22);
            testExampleMI.Text = "Тестовый пример";
            // 
            // bibliographyMI
            // 
            bibliographyMI.Name = "bibliographyMI";
            bibliographyMI.Size = new Size(231, 22);
            bibliographyMI.Text = "Список литературы";
            // 
            // gitURLMI
            // 
            gitURLMI.Name = "gitURLMI";
            gitURLMI.Size = new Size(231, 22);
            gitURLMI.Text = "Исходный код программы";
            // 
            // Run
            // 
            Run.Name = "Run";
            Run.Size = new Size(46, 19);
            Run.Text = "Пуск";
            Run.Click += Run_Click;
            // 
            // aboutMI
            // 
            aboutMI.Name = "aboutMI";
            aboutMI.Size = new Size(65, 19);
            aboutMI.Text = "Справка";
            aboutMI.Click += aboutMI_Click;
            // 
            // SettingsMI
            // 
            SettingsMI.Name = "SettingsMI";
            SettingsMI.Size = new Size(79, 19);
            SettingsMI.Text = "Настройки";
            SettingsMI.Click += SettingsMI_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 508);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1073, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.CanOverflow = false;
            toolStrip1.ImageScalingSize = new Size(38, 38);
            toolStrip1.Items.AddRange(new ToolStripItem[] { undoTSB, redoTSB, createTSB, saveTSB, saveUsTSB, copyTSB, cutTSB, selectAllTSB, deleteTabTSB });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            toolStrip1.Location = new Point(0, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1073, 45);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip";
            // 
            // undoTSB
            // 
            undoTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            undoTSB.Image = (Image)resources.GetObject("undoTSB.Image");
            undoTSB.ImageTransparentColor = Color.Magenta;
            undoTSB.Name = "undoTSB";
            undoTSB.Size = new Size(42, 42);
            undoTSB.Text = "Отменить";
            undoTSB.Click += undo_Click;
            // 
            // redoTSB
            // 
            redoTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            redoTSB.Image = (Image)resources.GetObject("redoTSB.Image");
            redoTSB.ImageTransparentColor = Color.Magenta;
            redoTSB.Name = "redoTSB";
            redoTSB.Size = new Size(42, 42);
            redoTSB.Text = "Вернуть";
            redoTSB.Click += redo_Click;
            // 
            // createTSB
            // 
            createTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            createTSB.Image = (Image)resources.GetObject("createTSB.Image");
            createTSB.ImageTransparentColor = Color.Magenta;
            createTSB.Name = "createTSB";
            createTSB.Size = new Size(42, 42);
            createTSB.Text = "Создать файл";
            createTSB.Click += createFile_Click;
            // 
            // saveTSB
            // 
            saveTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveTSB.Image = (Image)resources.GetObject("saveTSB.Image");
            saveTSB.ImageTransparentColor = Color.Magenta;
            saveTSB.Name = "saveTSB";
            saveTSB.Size = new Size(42, 42);
            saveTSB.Text = "Сохранить";
            saveTSB.Click += saveFile_Click;
            // 
            // saveUsTSB
            // 
            saveUsTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveUsTSB.Image = (Image)resources.GetObject("saveUsTSB.Image");
            saveUsTSB.ImageTransparentColor = Color.Magenta;
            saveUsTSB.Name = "saveUsTSB";
            saveUsTSB.Size = new Size(42, 42);
            saveUsTSB.Text = "Сохранить как";
            saveUsTSB.Click += saveUsFile_Click;
            // 
            // copyTSB
            // 
            copyTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyTSB.Image = (Image)resources.GetObject("copyTSB.Image");
            copyTSB.ImageTransparentColor = Color.Magenta;
            copyTSB.Name = "copyTSB";
            copyTSB.Size = new Size(42, 42);
            copyTSB.Text = "Копировать";
            copyTSB.Click += copy_Click;
            // 
            // cutTSB
            // 
            cutTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutTSB.Image = (Image)resources.GetObject("cutTSB.Image");
            cutTSB.ImageTransparentColor = Color.Magenta;
            cutTSB.Name = "cutTSB";
            cutTSB.Size = new Size(42, 42);
            cutTSB.Text = "Вырезать";
            cutTSB.Click += cut_Click;
            // 
            // selectAllTSB
            // 
            selectAllTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            selectAllTSB.Image = (Image)resources.GetObject("selectAllTSB.Image");
            selectAllTSB.ImageTransparentColor = Color.Magenta;
            selectAllTSB.Name = "selectAllTSB";
            selectAllTSB.Size = new Size(42, 42);
            selectAllTSB.Text = "Выделить все";
            selectAllTSB.Click += selectAll_Click;
            // 
            // deleteTabTSB
            // 
            deleteTabTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            deleteTabTSB.Image = (Image)resources.GetObject("deleteTabTSB.Image");
            deleteTabTSB.ImageTransparentColor = Color.Magenta;
            deleteTabTSB.Name = "deleteTabTSB";
            deleteTabTSB.Size = new Size(42, 42);
            deleteTabTSB.Text = "Удалить вкладку";
            deleteTabTSB.Click += deleteTabTSB_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.GradientInactiveCaption;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 68);
            mainPanel.Name = "mainPanel";
            mainPanel.Orientation = Orientation.Horizontal;
            // 
            // mainPanel.Panel2
            // 
            mainPanel.Panel2.BackColor = SystemColors.Control;
            mainPanel.Panel2.Controls.Add(dataGridView);
            mainPanel.Size = new Size(1073, 440);
            mainPanel.SplitterDistance = 310;
            mainPanel.TabIndex = 3;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, FilePathColumn, LineColumn, ColumnColumn, MessageColumn });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.GridColor = Color.Gray;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(1073, 126);
            dataGridView.TabIndex = 0;
            // 
            // NumberColumn
            // 
            NumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NumberColumn.DataPropertyName = "Number";
            NumberColumn.Frozen = true;
            NumberColumn.HeaderText = "";
            NumberColumn.Name = "NumberColumn";
            NumberColumn.ReadOnly = true;
            NumberColumn.Width = 40;
            // 
            // FilePathColumn
            // 
            FilePathColumn.DataPropertyName = "FilePath";
            FilePathColumn.HeaderText = "Путь файла";
            FilePathColumn.Name = "FilePathColumn";
            FilePathColumn.ReadOnly = true;
            // 
            // LineColumn
            // 
            LineColumn.DataPropertyName = "Line";
            LineColumn.HeaderText = "Строка";
            LineColumn.Name = "LineColumn";
            LineColumn.ReadOnly = true;
            // 
            // ColumnColumn
            // 
            ColumnColumn.DataPropertyName = "Column";
            ColumnColumn.HeaderText = "Колонка";
            ColumnColumn.Name = "ColumnColumn";
            ColumnColumn.ReadOnly = true;
            // 
            // MessageColumn
            // 
            MessageColumn.DataPropertyName = "ExceptionMessage";
            MessageColumn.HeaderText = "Сообщение";
            MessageColumn.Name = "MessageColumn";
            MessageColumn.ReadOnly = true;
            // 
            // CompilerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1073, 530);
            Controls.Add(mainPanel);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(984, 510);
            Name = "CompilerForm";
            Text = "Компилятор";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            mainPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainPanel).EndInit();
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem FileTS;
        private ToolStripMenuItem createMI;
        private ToolStripMenuItem openMI;
        private ToolStripMenuItem SaveMI;
        private ToolStripMenuItem saveUsMI;
        private ToolStripMenuItem exitMI;
        private ToolStripMenuItem Edit;
        private ToolStripMenuItem undoMI;
        private ToolStripMenuItem redoMI;
        private ToolStripMenuItem cutMI;
        private ToolStripMenuItem copyMI;
        private ToolStripMenuItem insertMI;
        private ToolStripMenuItem deleteMI;
        private ToolStripMenuItem selectAllMI;
        private ToolStripMenuItem textMI;
        private ToolStripMenuItem taskAimIM;
        private ToolStripMenuItem grammaticMI;
        private ToolStripMenuItem typegrammaticMI;
        private ToolStripMenuItem methodAnalysisMI;
        private ToolStripMenuItem testExampleMI;
        private ToolStripMenuItem bibliographyMI;
        private ToolStripMenuItem gitURLMI;
        private ToolStripMenuItem Run;
        private ToolStripMenuItem aboutMI;
        private ToolStripMenuItem SettingsMI;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton undoTSB;
        private ToolStripButton redoTSB;
        private ToolStripButton createTSB;
        private ToolStripButton saveTSB;
        private ToolStripButton saveUsTSB;
        private ToolStripButton copyTSB;
        private ToolStripButton cutTSB;
        private ToolStripButton selectAllTSB;
        private ToolStripButton deleteTabTSB;
        private SplitContainer mainPanel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn NumberColumn;
        private DataGridViewTextBoxColumn FilePathColumn;
        private DataGridViewTextBoxColumn LineColumn;
        private DataGridViewTextBoxColumn MessageColumn;
        private DataGridViewTextBoxColumn ColumnColumn;
    }
}
