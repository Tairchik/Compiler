using CompilerGUI.Controllers;
using CompilerGUI.HelpClass;
using System.Media;

namespace CompilerGUI
{
    public partial class CompilerForm : Form
    {
        private TabPagesController controllerTCP;
        private SyncRedactorTextController controllerRichTB;
        private ExceptionsCodeController controllerExceptionsCode;
        private ConsoleController controllerConsole;
        private TextHighlightingController controllerTextHighlighting;
        private KeyController keyController;

        public CompilerForm()
        {
            InitializeComponent();
            ApplyLocalization();
            this.AllowDrop = true;
            mainPanel.AllowDrop = true;
            keyController = new KeyController();
            controllerTCP = new TabPagesController(mainPanel.Panel1);
            controllerExceptionsCode = new ExceptionsCodeController(this.dataGridView);
            controllerRichTB = new SyncRedactorTextController();
            controllerConsole = new ConsoleController();
            controllerTextHighlighting = new TextHighlightingController("txt");

            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerTCP.ZoomChanged += controllerRichTB.UpdateColumnWidth;
            controllerTCP.TextCodeChanged += controllerExceptionsCode.TextCodeChanged;
            controllerTCP.TabPageChangedE += controllerExceptionsCode.PageCodeChanged;
            controllerTCP.TabPageChanged += controllerConsole.InitCodeTextBox;
            controllerTCP.TabPageChanged += controllerTextHighlighting.InitTextBox;

            controllerRichTB.TextIsChange += controllerTCP.UpdatePageInfo;

            keyController.CapsLockChanged += OnCapsLockChanged;
            keyController.InputLanguageChanged += OnInputLanguageChanged;
            keyController.Initialize();
            keyController.CtrlSPressed += SaveFile;
            keyController.CtrlNPressed += CreateFile;
            keyController.CtrlOPressed += OpenFile;
            keyController.CtrlShiftSPressed += SaveUsFile;

            controllerTCP.TapPageKeyDown += keyController.OnKeyDown;

            controllerConsole.ChangeStatusRun += StatusChanged;
        }

        private void CompilerForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CompilerForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                controllerTCP.OpenFile(filePath);
            }
        }
        private void SaveFile()
        {
            controllerTCP.SaveFile();
        }
        private void OpenFile()
        {
            controllerTCP.OpenFile();
        }
        private void SaveUsFile()
        {
            controllerTCP.SaveUsFile();
        }
        private void CreateFile()
        {
            controllerTCP.CreateFile();
        }

        private void StatusChanged(string status)
        {
            statusRunLabel.Text = status;
        }

        private void OnCapsLockChanged(object sender, string statusMessage)
        {
            capsLockLabel.Text = statusMessage;
        }

        private void OnInputLanguageChanged(object sender, string lang)
        {
            languageLabel.Text = lang;
        }

        private void Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            keyController.OnInputLanguageChanged();
        }

        private void keyPressedMainForm(object sender, KeyEventArgs e)
        {
            keyController.OnKeyDown(e.KeyCode);
        }

        private void createFile_Click(object sender, EventArgs e)
        {
            controllerTCP.CreateFile();
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            controllerTCP.SaveFile();
        }

        private void saveUsFile_Click(object sender, EventArgs e)
        {
            controllerTCP.SaveUsFile();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            controllerTCP.OpenFile();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exit_Process(object sender, FormClosingEventArgs e)
        {
            if (controllerTCP.Exit(this) == false)
            {
                e.Cancel = true;
            }
        }

        private void copy_Click(object sender, EventArgs e)
        {
            string text = controllerRichTB.GetSelectedText();
            if (!string.IsNullOrEmpty(text))
            {
                Clipboard.SetText(text);
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void cut_Click(object sender, EventArgs e)
        {
            string text = controllerRichTB.GetSelectedTextAndCut();
            if (!string.IsNullOrEmpty(text))
            {
                Clipboard.SetText(text);
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            if (!controllerRichTB.SelectAllText())
            {
                SystemSounds.Beep.Play();
            }

        }

        private void deleteText_Click(object sender, EventArgs e)
        {
            if (!controllerRichTB.DeleteSelectedText())
            {
                SystemSounds.Beep.Play();
            }
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (!controllerRichTB.UndoText())
            {
                SystemSounds.Beep.Play();
            }
        }
        private void redo_Click(object sender, EventArgs e)
        {
            if (!controllerRichTB.RedoText())
            {
                SystemSounds.Beep.Play();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (!controllerRichTB.InsertText())
            {
                SystemSounds.Beep.Play();
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            controllerConsole.StartCode();
        }

        private void aboutMI_Click(object sender, EventArgs e)
        {

        }

        private void SettingsMI_Click(object sender, EventArgs e)
        {
            Settings setForm = new Settings(LocalizationService.CurrentLanguage);

            if (setForm.ShowDialog() == DialogResult.OK)
            {
                LocalizationService.ChangeLanguage(setForm.Language);
                ApplyLocalization();
            }
        }

        private void deleteTabTSB_Click(object sender, EventArgs e)
        {
            controllerTCP.CloseTabe();
        }

        private void zoomPlus_Click(object sender, EventArgs e)
        {
            controllerTCP.ChangeZoomText(0.1f);
        }
        private void zoomMinus_Click(object sender, EventArgs e)
        {
            controllerTCP.ChangeZoomText(-0.1f);
        }

        private void ApplyLocalization()
        {
            FileTS.Text = LocalizationService.Get("File");
            Edit.Text = LocalizationService.Get("Edit");
            Run.Text = LocalizationService.Get("Run");
            SettingsMI.Text = LocalizationService.Get("Settings");
            exitMI.Text = LocalizationService.Get("Exit");
            createMI.Text = LocalizationService.Get("Create");
            openMI.Text = LocalizationService.Get("Open");
            SaveMI.Text = LocalizationService.Get("Save");
            saveUsMI.Text = LocalizationService.Get("SaveUs");
            undoMI.Text = LocalizationService.Get("Undo");
            redoMI.Text = LocalizationService.Get("Redo");
            cutMI.Text = LocalizationService.Get("Cut");
            copyMI.Text = LocalizationService.Get("Copy");
            insertMI.Text = LocalizationService.Get("Insert");
            deleteMI.Text = LocalizationService.Get("Delete");
            selectAllMI.Text = LocalizationService.Get("SelectAll");
            textMI.Text = LocalizationService.Get("Text");
            taskAimIM.Text = LocalizationService.Get("SettingTheTask");
            grammaticMI.Text = LocalizationService.Get("Grammatic");
            typegrammaticMI.Text = LocalizationService.Get("ClassificationGrammatic");
            methodAnalysisMI.Text = LocalizationService.Get("TheMethodOfAnalysis");
            testExampleMI.Text = LocalizationService.Get("ATestCase");
            bibliographyMI.Text = LocalizationService.Get("ListOfLiterature");
            gitURLMI.Text = LocalizationService.Get("TheSourceCodeOfTheProgram");
            aboutMI.Text = LocalizationService.Get("Help");
            undoTSB.Text = LocalizationService.Get("Undo");
            redoTSB.Text = LocalizationService.Get("Redo");
            createTSB.Text = LocalizationService.Get("Create");
            saveTSB.Text = LocalizationService.Get("Save");
            saveUsTSB.Text = LocalizationService.Get("SaveUs");
            copyTSB.Text = LocalizationService.Get("Copy");
            cutTSB.Text = LocalizationService.Get("Cut");
            selectAllTSB.Text = LocalizationService.Get("SelectAll");
            deleteTabTSB.Text = LocalizationService.Get("CloseTab");
            StatusChanged(LocalizationService.Get("Ready"));
            keyController?.Initialize();

            this.Text = LocalizationService.Get("Compiler");
            dataGridView.Columns["FilePathColumn"].HeaderText = LocalizationService.Get("FilePath");
            dataGridView.Columns["ColumnColumn"].HeaderText = LocalizationService.Get("Column");
            dataGridView.Columns["LineColumn"].HeaderText = LocalizationService.Get("Line");
            dataGridView.Columns["MessageColumn"].HeaderText = LocalizationService.Get("Message");
            dataGridView.Refresh();
        }

    }
}
