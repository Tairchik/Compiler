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
            menuStrip = new MenuStrip();
            FileTS = new ToolStripMenuItem();
            createMI = new ToolStripMenuItem();
            openMI = new ToolStripMenuItem();
            SaveMI = new ToolStripMenuItem();
            saveUsMI = new ToolStripMenuItem();
            exitMI = new ToolStripMenuItem();
            Edit = new ToolStripMenuItem();
            cancleMI = new ToolStripMenuItem();
            backMI = new ToolStripMenuItem();
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
            cancleTSB = new ToolStripButton();
            backTSB = new ToolStripButton();
            createTSB = new ToolStripButton();
            saveTSB = new ToolStripButton();
            saveUsTSB = new ToolStripButton();
            copyTSB = new ToolStripButton();
            cutTSB = new ToolStripButton();
            selectAllTSB = new ToolStripButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            richTextBox1 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            tabPage2 = new TabPage();
            menuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            menuStrip.Size = new Size(968, 23);
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
            createMI.Size = new Size(153, 22);
            createMI.Text = "Создать";
            // 
            // openMI
            // 
            openMI.Name = "openMI";
            openMI.Size = new Size(153, 22);
            openMI.Text = "Открыть";
            // 
            // SaveMI
            // 
            SaveMI.Name = "SaveMI";
            SaveMI.Size = new Size(153, 22);
            SaveMI.Text = "Сохранить";
            // 
            // saveUsMI
            // 
            saveUsMI.Name = "saveUsMI";
            saveUsMI.Size = new Size(153, 22);
            saveUsMI.Text = "Сохранить как";
            // 
            // exitMI
            // 
            exitMI.Name = "exitMI";
            exitMI.Size = new Size(153, 22);
            exitMI.Text = "Выход";
            // 
            // Edit
            // 
            Edit.DropDownItems.AddRange(new ToolStripItem[] { cancleMI, backMI, cutMI, copyMI, insertMI, deleteMI, selectAllMI });
            Edit.Name = "Edit";
            Edit.Size = new Size(59, 19);
            Edit.Text = "Правка";
            // 
            // cancleMI
            // 
            cancleMI.Name = "cancleMI";
            cancleMI.Size = new Size(148, 22);
            cancleMI.Text = "Отменить";
            // 
            // backMI
            // 
            backMI.Name = "backMI";
            backMI.Size = new Size(148, 22);
            backMI.Text = "Вернуть";
            // 
            // cutMI
            // 
            cutMI.Name = "cutMI";
            cutMI.Size = new Size(148, 22);
            cutMI.Text = "Вырезать";
            // 
            // copyMI
            // 
            copyMI.Name = "copyMI";
            copyMI.Size = new Size(148, 22);
            copyMI.Text = "Копировать";
            // 
            // insertMI
            // 
            insertMI.Name = "insertMI";
            insertMI.Size = new Size(148, 22);
            insertMI.Text = "Вставить";
            // 
            // deleteMI
            // 
            deleteMI.Name = "deleteMI";
            deleteMI.Size = new Size(148, 22);
            deleteMI.Text = "Удалить";
            // 
            // selectAllMI
            // 
            selectAllMI.Name = "selectAllMI";
            selectAllMI.Size = new Size(148, 22);
            selectAllMI.Text = "Выделить все";
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
            // 
            // aboutMI
            // 
            aboutMI.Name = "aboutMI";
            aboutMI.Size = new Size(65, 19);
            aboutMI.Text = "Справка";
            // 
            // SettingsMI
            // 
            SettingsMI.Name = "SettingsMI";
            SettingsMI.Size = new Size(79, 19);
            SettingsMI.Text = "Настройки";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 449);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(968, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.CanOverflow = false;
            toolStrip1.ImageScalingSize = new Size(38, 38);
            toolStrip1.Items.AddRange(new ToolStripItem[] { cancleTSB, backTSB, createTSB, saveTSB, saveUsTSB, copyTSB, cutTSB, selectAllTSB });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            toolStrip1.Location = new Point(0, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(968, 45);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip";
            // 
            // cancleTSB
            // 
            cancleTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cancleTSB.Image = (Image)resources.GetObject("cancleTSB.Image");
            cancleTSB.ImageTransparentColor = Color.Magenta;
            cancleTSB.Name = "cancleTSB";
            cancleTSB.Size = new Size(42, 42);
            cancleTSB.Text = "Отменить";
            // 
            // backTSB
            // 
            backTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            backTSB.Image = (Image)resources.GetObject("backTSB.Image");
            backTSB.ImageTransparentColor = Color.Magenta;
            backTSB.Name = "backTSB";
            backTSB.Size = new Size(42, 42);
            backTSB.Text = "Вернуть";
            // 
            // createTSB
            // 
            createTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            createTSB.Image = (Image)resources.GetObject("createTSB.Image");
            createTSB.ImageTransparentColor = Color.Magenta;
            createTSB.Name = "createTSB";
            createTSB.Size = new Size(42, 42);
            createTSB.Text = "Создать файл";
            // 
            // saveTSB
            // 
            saveTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveTSB.Image = (Image)resources.GetObject("saveTSB.Image");
            saveTSB.ImageTransparentColor = Color.Magenta;
            saveTSB.Name = "saveTSB";
            saveTSB.Size = new Size(42, 42);
            saveTSB.Text = "Сохранить";
            // 
            // saveUsTSB
            // 
            saveUsTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveUsTSB.Image = (Image)resources.GetObject("saveUsTSB.Image");
            saveUsTSB.ImageTransparentColor = Color.Magenta;
            saveUsTSB.Name = "saveUsTSB";
            saveUsTSB.Size = new Size(42, 42);
            saveUsTSB.Text = "toolStripButton5";
            saveUsTSB.ToolTipText = "Сохранить как";
            // 
            // copyTSB
            // 
            copyTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyTSB.Image = (Image)resources.GetObject("copyTSB.Image");
            copyTSB.ImageTransparentColor = Color.Magenta;
            copyTSB.Name = "copyTSB";
            copyTSB.Size = new Size(42, 42);
            copyTSB.Text = "toolStripButton6";
            // 
            // cutTSB
            // 
            cutTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutTSB.Image = (Image)resources.GetObject("cutTSB.Image");
            cutTSB.ImageTransparentColor = Color.Magenta;
            cutTSB.Name = "cutTSB";
            cutTSB.Size = new Size(42, 42);
            cutTSB.Text = "toolStripButton7";
            // 
            // selectAllTSB
            // 
            selectAllTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            selectAllTSB.Image = (Image)resources.GetObject("selectAllTSB.Image");
            selectAllTSB.ImageTransparentColor = Color.Magenta;
            selectAllTSB.Name = "selectAllTSB";
            selectAllTSB.Size = new Size(42, 42);
            selectAllTSB.Text = "toolStripButton8";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 68);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(968, 381);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(960, 353);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(954, 347);
            splitContainer1.SplitterDistance = 189;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95F));
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(richTextBox3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(954, 189);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.DetectUrls = false;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Margin = new Padding(0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(47, 189);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Dock = DockStyle.Fill;
            richTextBox3.Location = new Point(47, 0);
            richTextBox3.Margin = new Padding(0);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(907, 189);
            richTextBox3.TabIndex = 1;
            richTextBox3.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(960, 353);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // CompilerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 471);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "CompilerForm";
            Text = "Компилятор";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
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
        private ToolStripMenuItem cancleMI;
        private ToolStripMenuItem backMI;
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
        private ToolStripButton cancleTSB;
        private ToolStripButton backTSB;
        private ToolStripButton createTSB;
        private ToolStripButton saveTSB;
        private ToolStripButton saveUsTSB;
        private ToolStripButton copyTSB;
        private ToolStripButton cutTSB;
        private ToolStripButton selectAllTSB;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox3;
    }
}
