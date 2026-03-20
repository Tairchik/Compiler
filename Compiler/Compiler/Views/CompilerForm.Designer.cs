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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1Lexer = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2Lexer = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3Lexer = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1FlexBison = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2FlexBison = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3FlexBison = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1Antlr = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2Antlr = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3Antlr = new DataGridViewCellStyle();
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
            aboutMI = new ToolStripMenuItem();
            helpMI = new ToolStripMenuItem();
            AboutProgramMI = new ToolStripMenuItem();
            Run = new ToolStripMenuItem();
            SettingsMI = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusRunLabel = new ToolStripStatusLabel();
            capsLockLabel = new ToolStripStatusLabel();
            languageLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            undoTSB = new ToolStripButton();
            redoTSB = new ToolStripButton();
            createTSB = new ToolStripButton();
            openTSB = new ToolStripButton();
            saveTSB = new ToolStripButton();
            saveUsTSB = new ToolStripButton();
            copyTSB = new ToolStripButton();
            cutTSB = new ToolStripButton();
            selectAllTSB = new ToolStripButton();
            zoomPlus = new ToolStripButton();
            zoomMinus = new ToolStripButton();
            deleteTabTSB = new ToolStripButton();
            runBtn = new ToolStripButton();
            aboutProgramBtn = new ToolStripButton();
            helpBtn = new ToolStripButton();
            mainPanel = new SplitContainer();
            dataGridView = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            InvalidText = new DataGridViewTextBoxColumn();
            LineColumn = new DataGridViewTextBoxColumn();
            MessageColumn = new DataGridViewTextBoxColumn();
            dataGridViewLexer = new DataGridView();
            codeColumn = new DataGridViewTextBoxColumn();
            typeColumn = new DataGridViewTextBoxColumn();
            lexemeColumn = new DataGridViewTextBoxColumn();
            locationColumn = new DataGridViewTextBoxColumn();
            dataGridViewFlexBison = new DataGridView();
            numberColumnFlexBison = new DataGridViewTextBoxColumn();
            invalidTextFlexBison = new DataGridViewTextBoxColumn();
            lineColumnFlexBison = new DataGridViewTextBoxColumn();
            messageColumnFlexBison = new DataGridViewTextBoxColumn();
            dataGridViewAntlr = new DataGridView();
            numberColumnAntlr = new DataGridViewTextBoxColumn();
            invalidTextAntlr = new DataGridViewTextBoxColumn();
            lineColumnAntlr = new DataGridViewTextBoxColumn();
            messageColumnAntlr = new DataGridViewTextBoxColumn();
            gridTabControl = new TabControl();
            tabPageSyntax = new TabPage();
            tabPageFlexBison = new TabPage();
            tabPageLexer = new TabPage();
            tabPageAntlr = new TabPage();
            menuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { FileTS, Edit, textMI, aboutMI, Run, SettingsMI });
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
            // aboutMI
            // 
            aboutMI.DropDownItems.AddRange(new ToolStripItem[] { helpMI, AboutProgramMI });
            aboutMI.Name = "aboutMI";
            aboutMI.Size = new Size(65, 19);
            aboutMI.Text = "Справка";
            // 
            // helpMI
            // 
            helpMI.Name = "helpMI";
            helpMI.ShortcutKeyDisplayString = "Ctrl+H";
            helpMI.Size = new Size(199, 22);
            helpMI.Text = "Вызов справки";
            helpMI.Click += helpMI_Click;
            // 
            // AboutProgramMI
            // 
            AboutProgramMI.Name = "AboutProgramMI";
            AboutProgramMI.Size = new Size(199, 22);
            AboutProgramMI.Text = "О программе";
            AboutProgramMI.Click += AboutProgramMI_Click;
            // 
            // Run
            // 
            Run.Name = "Run";
            Run.Size = new Size(46, 19);
            Run.Text = "Пуск";
            Run.Click += Run_Click;
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusRunLabel, capsLockLabel, languageLabel });
            statusStrip1.Location = new Point(0, 508);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1073, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusRunLabel
            // 
            statusRunLabel.Name = "statusRunLabel";
            statusRunLabel.Padding = new Padding(10, 0, 0, 0);
            statusRunLabel.Size = new Size(55, 17);
            statusRunLabel.Text = "Готово";
            // 
            // capsLockLabel
            // 
            capsLockLabel.Name = "capsLockLabel";
            capsLockLabel.Size = new Size(837, 17);
            capsLockLabel.Spring = true;
            capsLockLabel.Text = "Клавиша CapsLock нажата";
            capsLockLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // languageLabel
            // 
            languageLabel.Name = "languageLabel";
            languageLabel.Padding = new Padding(30, 0, 0, 0);
            languageLabel.Size = new Size(168, 17);
            languageLabel.Text = "Язык ввода Английский";
            // 
            // toolStrip1
            // 
            toolStrip1.CanOverflow = false;
            toolStrip1.ImageScalingSize = new Size(38, 38);
            toolStrip1.Items.AddRange(new ToolStripItem[] { undoTSB, redoTSB, createTSB, openTSB, saveTSB, saveUsTSB, copyTSB, cutTSB, selectAllTSB, zoomPlus, zoomMinus, deleteTabTSB, runBtn, aboutProgramBtn, helpBtn });
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
            createTSB.ImageAlign = ContentAlignment.MiddleRight;
            createTSB.ImageTransparentColor = Color.Magenta;
            createTSB.Margin = new Padding(42, 1, 0, 2);
            createTSB.Name = "createTSB";
            createTSB.Size = new Size(42, 42);
            createTSB.Text = "Создать файл";
            createTSB.Click += createFile_Click;
            // 
            // openTSB
            // 
            openTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openTSB.Image = (Image)resources.GetObject("openTSB.Image");
            openTSB.ImageTransparentColor = Color.Magenta;
            openTSB.Name = "openTSB";
            openTSB.Size = new Size(42, 42);
            openTSB.Text = "Открыть";
            openTSB.Click += openTSB_Click;
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
            copyTSB.ImageAlign = ContentAlignment.MiddleRight;
            copyTSB.ImageTransparentColor = Color.Magenta;
            copyTSB.Margin = new Padding(42, 1, 0, 2);
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
            // zoomPlus
            // 
            zoomPlus.DisplayStyle = ToolStripItemDisplayStyle.Image;
            zoomPlus.Image = (Image)resources.GetObject("zoomPlus.Image");
            zoomPlus.ImageTransparentColor = Color.Magenta;
            zoomPlus.Name = "zoomPlus";
            zoomPlus.Size = new Size(42, 42);
            zoomPlus.Text = "Увеличить текст";
            zoomPlus.Click += zoomPlus_Click;
            // 
            // zoomMinus
            // 
            zoomMinus.DisplayStyle = ToolStripItemDisplayStyle.Image;
            zoomMinus.Image = (Image)resources.GetObject("zoomMinus.Image");
            zoomMinus.ImageTransparentColor = Color.Magenta;
            zoomMinus.Name = "zoomMinus";
            zoomMinus.Size = new Size(42, 42);
            zoomMinus.Text = "Уменьшить текст";
            zoomMinus.Click += zoomMinus_Click;
            // 
            // deleteTabTSB
            // 
            deleteTabTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            deleteTabTSB.Image = (Image)resources.GetObject("deleteTabTSB.Image");
            deleteTabTSB.ImageTransparentColor = Color.Magenta;
            deleteTabTSB.Margin = new Padding(42, 1, 42, 2);
            deleteTabTSB.Name = "deleteTabTSB";
            deleteTabTSB.Size = new Size(42, 42);
            deleteTabTSB.Text = "Удалить вкладку";
            deleteTabTSB.Click += deleteTabTSB_Click;
            // 
            // runBtn
            // 
            runBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            runBtn.Image = (Image)resources.GetObject("runBtn.Image");
            runBtn.ImageTransparentColor = Color.Magenta;
            runBtn.Name = "runBtn";
            runBtn.RightToLeft = RightToLeft.No;
            runBtn.Size = new Size(42, 42);
            runBtn.Text = "Пуск";
            runBtn.Click += runBtn_Click;
            // 
            // aboutProgramBtn
            // 
            aboutProgramBtn.Alignment = ToolStripItemAlignment.Right;
            aboutProgramBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            aboutProgramBtn.Image = (Image)resources.GetObject("aboutProgramBtn.Image");
            aboutProgramBtn.ImageTransparentColor = Color.Magenta;
            aboutProgramBtn.Name = "aboutProgramBtn";
            aboutProgramBtn.Size = new Size(42, 42);
            aboutProgramBtn.Text = "О программе";
            aboutProgramBtn.Click += aboutProgramBtn_Click;
            // 
            // helpBtn
            // 
            helpBtn.Alignment = ToolStripItemAlignment.Right;
            helpBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpBtn.Image = (Image)resources.GetObject("helpBtn.Image");
            helpBtn.ImageAlign = ContentAlignment.MiddleRight;
            helpBtn.ImageTransparentColor = Color.Magenta;
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new Size(42, 42);
            helpBtn.Text = "Помощь";
            helpBtn.Click += helpBtn_Click;
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
            mainPanel.Panel2.Controls.Add(gridTabControl);
            mainPanel.Size = new Size(1073, 440);
            mainPanel.SplitterDistance = 310;
            mainPanel.TabIndex = 3;
            mainPanel.DragDrop += CompilerForm_DragDrop;
            mainPanel.DragEnter += CompilerForm_DragEnter;
            mainPanel.KeyDown += keyPressedMainForm;
            //
            // gridTabControl
            //
            gridTabControl.Dock = DockStyle.Fill;
            gridTabControl.Name = "gridTabControl";
            gridTabControl.Controls.Add(tabPageSyntax);
            gridTabControl.Controls.Add(tabPageLexer);
            gridTabControl.Controls.Add(tabPageFlexBison);
            gridTabControl.Controls.Add(tabPageAntlr);
            //
            // tabPageSyntax
            //
            tabPageSyntax.Name = "tabPageSyntax";
            tabPageSyntax.Padding = new Padding(3);
            tabPageSyntax.TabIndex = 0;
            tabPageSyntax.Text = "Синтаксический анализатор";
            tabPageSyntax.Controls.Add(dataGridView);
            tabPageSyntax.UseVisualStyleBackColor = true;
            //
            // tabPageLexer
            //
            tabPageLexer.Name = "tabPageLexer";
            tabPageLexer.Padding = new Padding(3);
            tabPageLexer.TabIndex = 0;
            tabPageLexer.Text = "Лексический анализатор";
            tabPageLexer.Controls.Add(dataGridViewLexer);
            tabPageLexer.UseVisualStyleBackColor = true;
            //
            // tabPageFlexBison
            //
            tabPageFlexBison.Name = "tabPageFlexBison";
            tabPageFlexBison.Padding = new Padding(3);
            tabPageFlexBison.TabIndex = 0;
            tabPageFlexBison.Text = "Flex&Bison";
            tabPageFlexBison.Controls.Add(dataGridViewFlexBison);
            tabPageFlexBison.UseVisualStyleBackColor = true;
            //
            // tabPageAntlr            
            //
            tabPageAntlr.Name = "tabPageAntlr";
            tabPageAntlr.Padding = new Padding(3);
            tabPageAntlr.TabIndex = 0;
            tabPageAntlr.Text = "ANTLR";
            tabPageAntlr.Controls.Add(dataGridViewAntlr);
            tabPageAntlr.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, InvalidText, LineColumn, MessageColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.GridColor = Color.Gray;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            // InvalidText
            // 
            InvalidText.DataPropertyName = "InvalidText";
            InvalidText.HeaderText = "Неверный фрагмент";
            InvalidText.Name = "InvalidText";
            InvalidText.ReadOnly = true;
            // 
            // LineColumn
            // 
            LineColumn.DataPropertyName = "Location";
            LineColumn.HeaderText = "Местоположение";
            LineColumn.Name = "LineColumn";
            LineColumn.ReadOnly = true;
            // 
            // MessageColumn
            // 
            MessageColumn.DataPropertyName = "ExceptionMessage";
            MessageColumn.HeaderText = "Сообщение";
            MessageColumn.Name = "MessageColumn";
            MessageColumn.ReadOnly = true;
            // 
            // dataGridViewFlexBison
            // 
            dataGridViewFlexBison.AllowUserToAddRows = false;
            dataGridViewFlexBison.AllowUserToDeleteRows = false;
            dataGridViewFlexBison.AllowUserToResizeRows = false;
            dataGridViewFlexBison.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFlexBison.BackgroundColor = Color.White;
            dataGridViewFlexBison.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1FlexBison.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1FlexBison.BackColor = SystemColors.Control;
            dataGridViewCellStyle1FlexBison.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1FlexBison.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1FlexBison.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1FlexBison.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1FlexBison.WrapMode = DataGridViewTriState.True;
            dataGridViewFlexBison.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1FlexBison;
            dataGridViewFlexBison.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFlexBison.Columns.AddRange(new DataGridViewColumn[] { numberColumnFlexBison, invalidTextFlexBison, lineColumnFlexBison, messageColumnFlexBison });
            dataGridViewCellStyle2FlexBison.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2FlexBison.BackColor = SystemColors.Window;
            dataGridViewCellStyle2FlexBison.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2FlexBison.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2FlexBison.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2FlexBison.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2FlexBison.WrapMode = DataGridViewTriState.False;
            dataGridViewFlexBison.DefaultCellStyle = dataGridViewCellStyle2FlexBison;
            dataGridViewFlexBison.Dock = DockStyle.Fill;
            dataGridViewFlexBison.GridColor = Color.Gray;
            dataGridViewFlexBison.Location = new Point(0, 0);
            dataGridViewFlexBison.Name = "dataGridViewFlexBison";
            dataGridViewFlexBison.ReadOnly = true;
            dataGridViewCellStyle3FlexBison.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3FlexBison.BackColor = SystemColors.Control;
            dataGridViewCellStyle3FlexBison.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3FlexBison.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3FlexBison.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3FlexBison.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3FlexBison.WrapMode = DataGridViewTriState.True;
            dataGridViewFlexBison.RowHeadersDefaultCellStyle = dataGridViewCellStyle3FlexBison;
            dataGridViewFlexBison.RowHeadersVisible = false;
            dataGridViewFlexBison.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFlexBison.Size = new Size(1073, 126);
            dataGridViewFlexBison.TabIndex = 0;
            // 
            // numberColumnFlexBison
            // 
            numberColumnFlexBison.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numberColumnFlexBison.DataPropertyName = "Number";
            numberColumnFlexBison.Frozen = true;
            numberColumnFlexBison.HeaderText = "";
            numberColumnFlexBison.Name = "numberColumnFlexBison";
            numberColumnFlexBison.ReadOnly = true;
            numberColumnFlexBison.Width = 40;
            // 
            // invalidTextFlexBison
            // 
            invalidTextFlexBison.DataPropertyName = "InvalidText";
            invalidTextFlexBison.HeaderText = "Неверный фрагмент";
            invalidTextFlexBison.Name = "invalidTextFlexBison";
            invalidTextFlexBison.ReadOnly = true;
            // 
            // lineColumnFlexBison
            // 
            lineColumnFlexBison.DataPropertyName = "Location";
            lineColumnFlexBison.HeaderText = "Местоположение";
            lineColumnFlexBison.Name = "lineColumnFlexBison";
            lineColumnFlexBison.ReadOnly = true;
            // 
            // messageColumnFlexBison
            // 
            messageColumnFlexBison.DataPropertyName = "ExceptionMessage";
            messageColumnFlexBison.HeaderText = "Сообщение";
            messageColumnFlexBison.Name = "messageColumnFlexBison";
            messageColumnFlexBison.ReadOnly = true;
            // 
            // dataGridViewAntlr
            // 
            dataGridViewAntlr.AllowUserToAddRows = false;
            dataGridViewAntlr.AllowUserToDeleteRows = false;
            dataGridViewAntlr.AllowUserToResizeRows = false;
            dataGridViewAntlr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAntlr.BackgroundColor = Color.White;
            dataGridViewAntlr.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1Antlr.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1Antlr.BackColor = SystemColors.Control;
            dataGridViewCellStyle1Antlr.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1Antlr.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1Antlr.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1Antlr.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1Antlr.WrapMode = DataGridViewTriState.True;
            dataGridViewAntlr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1Antlr;
            dataGridViewAntlr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAntlr.Columns.AddRange(new DataGridViewColumn[] { numberColumnAntlr, invalidTextAntlr, lineColumnAntlr, messageColumnAntlr });
            dataGridViewCellStyle2Antlr.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2Antlr.BackColor = SystemColors.Window;
            dataGridViewCellStyle2Antlr.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2Antlr.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2Antlr.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2Antlr.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2Antlr.WrapMode = DataGridViewTriState.False;
            dataGridViewAntlr.DefaultCellStyle = dataGridViewCellStyle2Antlr;
            dataGridViewAntlr.Dock = DockStyle.Fill;
            dataGridViewAntlr.GridColor = Color.Gray;
            dataGridViewAntlr.Location = new Point(0, 0);
            dataGridViewAntlr.Name = "dataGridViewAntlr";
            dataGridViewAntlr.ReadOnly = true;
            dataGridViewCellStyle3Antlr.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3Antlr.BackColor = SystemColors.Control;
            dataGridViewCellStyle3Antlr.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3Antlr.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3Antlr.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3Antlr.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3Antlr.WrapMode = DataGridViewTriState.True;
            dataGridViewAntlr.RowHeadersDefaultCellStyle = dataGridViewCellStyle3Antlr;
            dataGridViewAntlr.RowHeadersVisible = false;
            dataGridViewAntlr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAntlr.Size = new Size(1073, 126);
            dataGridViewAntlr.TabIndex = 0;
            // 
            // numberColumnAntlr
            // 
            numberColumnAntlr.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numberColumnAntlr.DataPropertyName = "Number";
            numberColumnAntlr.Frozen = true;
            numberColumnAntlr.HeaderText = "";
            numberColumnAntlr.Name = "numberColumnAntlr";
            numberColumnAntlr.ReadOnly = true;
            numberColumnAntlr.Width = 40;
            // 
            // invalidTextAntlr
            // 
            invalidTextAntlr.DataPropertyName = "InvalidText";
            invalidTextAntlr.HeaderText = "Неверный фрагмент";
            invalidTextAntlr.Name = "invalidTextAntlr";
            invalidTextAntlr.ReadOnly = true;
            // 
            // lineColumnAntlr
            // 
            lineColumnAntlr.DataPropertyName = "Location";
            lineColumnAntlr.HeaderText = "Местоположение";
            lineColumnAntlr.Name = "lineColumnAntlr";
            lineColumnAntlr.ReadOnly = true;
            // 
            // messageColumnAntlr
            // 
            messageColumnAntlr.DataPropertyName = "ExceptionMessage";
            messageColumnAntlr.HeaderText = "Сообщение";
            messageColumnAntlr.Name = "messageColumnAntlr";
            messageColumnAntlr.ReadOnly = true;
            // 
            // dataGridViewLexer
            // 
            dataGridViewLexer.AllowUserToAddRows = false;
            dataGridViewLexer.AllowUserToDeleteRows = false;
            dataGridViewLexer.AllowUserToResizeRows = false;
            dataGridViewLexer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLexer.BackgroundColor = Color.White;
            dataGridViewLexer.BorderStyle = BorderStyle.None;
            dataGridViewLexer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1Lexer.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1Lexer.BackColor = Color.White;
            dataGridViewCellStyle1Lexer.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1Lexer.ForeColor = Color.Black;
            dataGridViewCellStyle1Lexer.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle1Lexer.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1Lexer.WrapMode = DataGridViewTriState.False;
            dataGridViewLexer.DefaultCellStyle = dataGridViewCellStyle1Lexer;
            dataGridViewLexer.Columns.AddRange(new DataGridViewColumn[] { codeColumn, typeColumn, lexemeColumn, locationColumn });
            dataGridViewLexer.Dock = DockStyle.Fill;
            dataGridViewLexer.GridColor = Color.Black;
            dataGridViewLexer.Location = new Point(0, 0);
            dataGridViewLexer.MultiSelect = false;
            dataGridViewLexer.Name = "dataGridViewLexer";
            dataGridViewLexer.ReadOnly = true;
            dataGridViewLexer.RowHeadersVisible = false;
            dataGridViewLexer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLexer.Size = new Size(795, 975);
            dataGridViewLexer.TabIndex = 0;
            //
            // codeColumn
            //
            codeColumn.DataPropertyName = "Code";
            codeColumn.HeaderText = "Условный код";
            codeColumn.Name = "codeColumn";
            codeColumn.ReadOnly = true;
            //
            // typeColumn
            //
            typeColumn.DataPropertyName = "TypeName";
            typeColumn.HeaderText = "Тип лексемы";
            typeColumn.Name = "typeColumn";
            typeColumn.ReadOnly = true;
            //
            // lexemeColumn
            //
            lexemeColumn.DataPropertyName = "Value";
            lexemeColumn.HeaderText = "Лексема";
            lexemeColumn.Name = "lexemeColumn";
            lexemeColumn.ReadOnly = true;
            //
            // locationColumn
            //
            locationColumn.DataPropertyName = "Location";
            locationColumn.HeaderText = "Местоположение";
            locationColumn.Name = "locationColumn";
            locationColumn.ReadOnly = true;
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
            FormClosing += exit_Process;
            InputLanguageChanged += Form_InputLanguageChanged;
            DragDrop += CompilerForm_DragDrop;
            DragEnter += CompilerForm_DragEnter;
            KeyDown += keyPressedMainForm;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private TabControl gridTabControl;
        private TabPage tabPageSyntax;
        private TabPage tabPageFlexBison;
        private TabPage tabPageLexer;
        private TabPage tabPageAntlr;
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
        private DataGridView dataGridViewLexer;
        private DataGridView dataGridViewFlexBison;
        private DataGridView dataGridViewAntlr;
        private ToolStripStatusLabel statusRunLabel;
        private ToolStripStatusLabel capsLockLabel;
        private ToolStripStatusLabel languageLabel;
        private ToolStripButton zoomPlus;
        private ToolStripButton zoomMinus;
        private ToolStripMenuItem helpMI;
        private ToolStripMenuItem AboutProgramMI;
        private ToolStripButton helpBtn;
        private ToolStripButton aboutProgramBtn;
        private ToolStripButton runBtn;
        private ToolStripButton openTSB;
        private DataGridViewTextBoxColumn NumberColumn;
        private DataGridViewTextBoxColumn InvalidText;
        private DataGridViewTextBoxColumn LineColumn;
        private DataGridViewTextBoxColumn MessageColumn;
        private DataGridViewTextBoxColumn codeColumn;
        private DataGridViewTextBoxColumn typeColumn;
        private DataGridViewTextBoxColumn lexemeColumn;
        private DataGridViewTextBoxColumn locationColumn;
        private DataGridViewTextBoxColumn numberColumnFlexBison;
        private DataGridViewTextBoxColumn invalidTextFlexBison;
        private DataGridViewTextBoxColumn lineColumnFlexBison;
        private DataGridViewTextBoxColumn messageColumnFlexBison;
        private DataGridViewTextBoxColumn numberColumnAntlr;
        private DataGridViewTextBoxColumn invalidTextAntlr;
        private DataGridViewTextBoxColumn lineColumnAntlr;
        private DataGridViewTextBoxColumn messageColumnAntlr;
    }
}
