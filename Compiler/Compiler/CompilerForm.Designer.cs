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
            menuStrip1 = new MenuStrip();
            FileTS = new ToolStripMenuItem();
            createMI = new ToolStripMenuItem();
            openMI = new ToolStripMenuItem();
            SaveMI = new ToolStripMenuItem();
            saveForMI = new ToolStripMenuItem();
            exitMI = new ToolStripMenuItem();
            Edit = new ToolStripMenuItem();
            cancelMI = new ToolStripMenuItem();
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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileTS, Edit, textMI, Run, aboutMI });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileTS
            // 
            FileTS.DropDownItems.AddRange(new ToolStripItem[] { createMI, openMI, SaveMI, saveForMI, exitMI });
            FileTS.Name = "FileTS";
            FileTS.Size = new Size(59, 24);
            FileTS.Text = "Файл";
            // 
            // createMI
            // 
            createMI.Name = "createMI";
            createMI.Size = new Size(192, 26);
            createMI.Text = "Создать";
            // 
            // openMI
            // 
            openMI.Name = "openMI";
            openMI.Size = new Size(192, 26);
            openMI.Text = "Открыть";
            // 
            // SaveMI
            // 
            SaveMI.Name = "SaveMI";
            SaveMI.Size = new Size(192, 26);
            SaveMI.Text = "Сохранить";
            // 
            // saveForMI
            // 
            saveForMI.Name = "saveForMI";
            saveForMI.Size = new Size(192, 26);
            saveForMI.Text = "Сохранить как";
            // 
            // exitMI
            // 
            exitMI.Name = "exitMI";
            exitMI.Size = new Size(192, 26);
            exitMI.Text = "Выход";
            // 
            // Edit
            // 
            Edit.DropDownItems.AddRange(new ToolStripItem[] { cancelMI, backMI, cutMI, copyMI, insertMI, deleteMI, selectAllMI });
            Edit.Name = "Edit";
            Edit.Size = new Size(74, 24);
            Edit.Text = "Правка";
            // 
            // cancelMI
            // 
            cancelMI.Name = "cancelMI";
            cancelMI.Size = new Size(224, 26);
            cancelMI.Text = "Отменить";
            // 
            // backMI
            // 
            backMI.Name = "backMI";
            backMI.Size = new Size(224, 26);
            backMI.Text = "Вернуть";
            // 
            // cutMI
            // 
            cutMI.Name = "cutMI";
            cutMI.Size = new Size(224, 26);
            cutMI.Text = "Вырезать";
            // 
            // copyMI
            // 
            copyMI.Name = "copyMI";
            copyMI.Size = new Size(224, 26);
            copyMI.Text = "Копировать";
            // 
            // insertMI
            // 
            insertMI.Name = "insertMI";
            insertMI.Size = new Size(224, 26);
            insertMI.Text = "Вставить";
            // 
            // deleteMI
            // 
            deleteMI.Name = "deleteMI";
            deleteMI.Size = new Size(224, 26);
            deleteMI.Text = "Удалить";
            // 
            // selectAllMI
            // 
            selectAllMI.Name = "selectAllMI";
            selectAllMI.Size = new Size(224, 26);
            selectAllMI.Text = "Выделить все";
            // 
            // textMI
            // 
            textMI.BackgroundImageLayout = ImageLayout.Stretch;
            textMI.DropDownItems.AddRange(new ToolStripItem[] { taskAimIM, grammaticMI, typegrammaticMI, methodAnalysisMI, testExampleMI, bibliographyMI, gitURLMI });
            textMI.Name = "textMI";
            textMI.Size = new Size(59, 24);
            textMI.Text = "Текст";
            textMI.Visible = false;
            // 
            // taskAimIM
            // 
            taskAimIM.Name = "taskAimIM";
            taskAimIM.Size = new Size(288, 26);
            taskAimIM.Text = "Постановка задачи";
            // 
            // grammaticMI
            // 
            grammaticMI.Name = "grammaticMI";
            grammaticMI.Size = new Size(288, 26);
            grammaticMI.Text = "Грамматика";
            // 
            // typegrammaticMI
            // 
            typegrammaticMI.Name = "typegrammaticMI";
            typegrammaticMI.Size = new Size(288, 26);
            typegrammaticMI.Text = "Классификация грамматики";
            // 
            // methodAnalysisMI
            // 
            methodAnalysisMI.Name = "methodAnalysisMI";
            methodAnalysisMI.Size = new Size(288, 26);
            methodAnalysisMI.Text = "Метод анализа";
            // 
            // testExampleMI
            // 
            testExampleMI.Name = "testExampleMI";
            testExampleMI.Size = new Size(288, 26);
            testExampleMI.Text = "Тестовый пример";
            // 
            // bibliographyMI
            // 
            bibliographyMI.Name = "bibliographyMI";
            bibliographyMI.Size = new Size(288, 26);
            bibliographyMI.Text = "Список литературы";
            // 
            // gitURLMI
            // 
            gitURLMI.Name = "gitURLMI";
            gitURLMI.Size = new Size(288, 26);
            gitURLMI.Text = "Исходный код программы";
            // 
            // Run
            // 
            Run.Name = "Run";
            Run.Size = new Size(55, 24);
            Run.Text = "Пуск";
            // 
            // aboutMI
            // 
            aboutMI.Name = "aboutMI";
            aboutMI.Size = new Size(81, 24);
            aboutMI.Text = "Справка";
            // 
            // CompilerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CompilerForm";
            Text = "Компилятор";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileTS;
        private ToolStripMenuItem createMI;
        private ToolStripMenuItem openMI;
        private ToolStripMenuItem SaveMI;
        private ToolStripMenuItem saveForMI;
        private ToolStripMenuItem exitMI;
        private ToolStripMenuItem Edit;
        private ToolStripMenuItem cancelMI;
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
    }
}
