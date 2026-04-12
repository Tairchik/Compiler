using CompilerGUI.Controllers;
using CompilerGUI.HelpClass;
using CompilerGUI.Properties;
using CompilerGUI.Scaner;
using CompilerGUI.Views;
using System.Diagnostics;
using System.Media;
using System.Security.Policy;

namespace CompilerGUI
{
    public partial class CompilerForm : Form
    {
        private TabPagesController controllerTCP;
        private SyncRedactorTextController controllerRichTB;
        private ExceptionsCodeController controllerExceptionsCode;
        private ConsoleController controllerConsole;
        private KeyController keyController;

        public CompilerForm()
        {
            InitializeComponent();
            ApplyLocalization();
            this.AllowDrop = true;
            mainPanel.AllowDrop = true;
            keyController = new KeyController();
            controllerTCP = new TabPagesController(mainPanel.Panel1);
            controllerExceptionsCode = new ExceptionsCodeController(this.dataGridView, this.dataGridViewLexer);
            controllerRichTB = new SyncRedactorTextController();
            controllerConsole = new ConsoleController(controllerExceptionsCode);

            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerTCP.ZoomChanged += controllerRichTB.UpdateColumnWidth;
            controllerTCP.TabClose += controllerExceptionsCode.Clear;
            controllerRichTB.TextIsChange += controllerTCP.UpdatePageInfo;

            keyController.CapsLockChanged += OnCapsLockChanged;
            keyController.InputLanguageChanged += OnInputLanguageChanged;
            keyController.Initialize();
            keyController.CtrlSPressed += SaveFile;
            keyController.CtrlNPressed += CreateFile;
            keyController.CtrlOPressed += OpenFile;
            keyController.CtrlHPressed += OpenHelp;
            keyController.CtrlShiftSPressed += SaveUsFile;

            controllerTCP.TapPageKeyDown += keyController.OnKeyDown;

            controllerConsole.ChangeStatusRun += StatusChanged;
            controllerConsole.ScanCompleted += OpenTableResultScan;
            controllerConsole.UpdateConsoleOutPut += controllerTCP.UpdateTextConsole;

            controllerExceptionsCode.GetFileClass += controllerTCP.GetFileClassPage;
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            dataGridViewLexer.CellDoubleClick += DataGridViewLexer_CellDoubleClick;
        }

        private void DataGridViewLexer_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            GridException_RowSelected(controllerExceptionsCode.gridLinesLexer[e.RowIndex]);
        }

        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            GridException_RowSelected(controllerExceptionsCode.gridLines[e.RowIndex]);
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
        private void OpenHelp()
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
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

        private void helpMI_Click(object sender, EventArgs e)
        {
            OpenHelp();
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
            (string text, bool res) = controllerTCP.GetTextEditor();
            if (res != false)
            controllerConsole.StartCode(text);
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
        private void runBtn_Click(object sender, EventArgs e)
        {
            (string text, bool res) = controllerTCP.GetTextEditor();
            if (res != false)
                controllerConsole.StartCode(text);
        }
        private void zoomPlus_Click(object sender, EventArgs e)
        {
            controllerTCP.ChangeZoomText(0.1f);
        }
        private void zoomMinus_Click(object sender, EventArgs e)
        {
            controllerTCP.ChangeZoomText(-0.1f);
        }
        private void helpBtn_Click(object sender, EventArgs e)
        {
            OpenHelp();
        }
        private void aboutProgramBtn_Click(object sender, EventArgs e)
        {
            openReadMe();
        }
        private void openReadMe()
        {
            string url = "https://github.com/Tairchik/Compiler/blob/main/README.md";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть ссылку: " + ex.Message);
            }
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
            openTSB.Text = LocalizationService.Get("Open");
            createTSB.Text = LocalizationService.Get("Create");
            saveTSB.Text = LocalizationService.Get("Save");
            saveUsTSB.Text = LocalizationService.Get("SaveUs");
            copyTSB.Text = LocalizationService.Get("Copy");
            cutTSB.Text = LocalizationService.Get("Cut");
            selectAllTSB.Text = LocalizationService.Get("SelectAll");
            deleteTabTSB.Text = LocalizationService.Get("CloseTab");
            zoomPlus.Text = LocalizationService.Get("EnlargeText");
            zoomMinus.Text = LocalizationService.Get("ReduceText");
            helpMI.Text = LocalizationService.Get("CallingHelp");
            AboutProgramMI.Text = LocalizationService.Get("AboutProgram");
            helpBtn.Text = LocalizationService.Get("Help");
            aboutProgramBtn.Text = LocalizationService.Get("AboutProgram");
            runBtn.Text = LocalizationService.Get("Run");
            StatusChanged(LocalizationService.Get("Ready"));
            keyController?.Initialize();

            this.Text = LocalizationService.Get("Compiler");
            dataGridView.Columns["InvalidText"].HeaderText = LocalizationService.Get("InvalidText");
            dataGridView.Columns["LineColumn"].HeaderText = LocalizationService.Get("Location");
            dataGridView.Columns["MessageColumn"].HeaderText = LocalizationService.Get("Message");
            dataGridView.Refresh();

            dataGridViewLexer.Columns["codeColumn"].HeaderText = LocalizationService.Get("Code");
            dataGridViewLexer.Columns["typeColumn"].HeaderText = LocalizationService.Get("Type");
            dataGridViewLexer.Columns["lexemeColumn"].HeaderText = LocalizationService.Get("Lexeme");
            dataGridViewLexer.Columns["locationColumn"].HeaderText = LocalizationService.Get("Location");

            dataGridViewLexer.Refresh();

        }

        private void AboutProgramMI_Click(object sender, EventArgs e)
        {
            openReadMe();
        }

        private void openTSB_Click(object sender, EventArgs e)
        {
            controllerTCP.OpenFile();
        }

        private bool scanForm = false;
        private ScannerResultForm resultForm;
        private void OpenTableResultScan(List<Token> tokens)
        {
            if (tokens == null || tokens.Count == 0)
            {
                MessageBox.Show("Список токенов пуст.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (scanForm == false)
            {
                resultForm = new ScannerResultForm(tokens);
                resultForm.RowSelected -= ResultForm_RowSelected;
                resultForm.RowSelected += ResultForm_RowSelected;
                resultForm.CloseForm -= ResultForm_CloseForm;
                resultForm.CloseForm += ResultForm_CloseForm;
                scanForm = true;
                resultForm.Show();
                resultForm.Focus();
            }
            else
            {
                resultForm.UpdateGrid(tokens);
                resultForm.Focus();
            }
        }

        private void ResultForm_CloseForm()
        {
            scanForm = false;
        }

        private void ResultForm_RowSelected(Token obj)
        {
            controllerTCP.FocusToEditor(obj);
            this.Focus();
        }
        private void GridException_RowSelected(ExceptionInfo syntaxError)
        {
            controllerTCP.FocusToEditor(syntaxError.Column, syntaxError.EndPos, syntaxError.StartPos);
            this.Focus();
        }
        private void GridException_RowSelected(Token token)
        {
            controllerTCP.FocusToEditor(token.AbsoluteIndex, token.EndPos, token.StartPos);
            this.Focus();
        }

        private void taskAimIM_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("Task.html");
        }

        private void grammaticMI_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("Grammar.html");
        }

        private void typegrammaticMI_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("Classification.html");
        }

        private void methodAnalysisMI_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("Method.html");
        }

        private void testExampleMI_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("Tests.html");
        }

        private void bibliographyMI_Click(object sender, EventArgs e)
        {
            ResourceHelper.OpenHtml("References.html");
        }

        private void gitURLMI_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Tairchik/Compiler";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть ссылку: " + ex.Message);
            }
        }
    }
}
