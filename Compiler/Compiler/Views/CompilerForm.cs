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
        //private TextHighlightingController controllerTextHighlighting;
        private KeyController keyController;

        public CompilerForm()
        {
            InitializeComponent();
            ApplyLocalization();
            this.AllowDrop = true;
            mainPanel.AllowDrop = true;
            keyController = new KeyController();
            controllerTCP = new TabPagesController(mainPanel.Panel1);
            controllerExceptionsCode = new ExceptionsCodeController(this.dataGridView, this.dataGridViewLexer, this.dataGridViewFlexBison, this.dataGridViewAntlr);
            controllerRichTB = new SyncRedactorTextController();
            controllerConsole = new ConsoleController(controllerExceptionsCode);
            //controllerTextHighlighting = new TextHighlightingController("txt");

            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerTCP.ZoomChanged += controllerRichTB.UpdateColumnWidth;
            //controllerTCP.TabPageChanged += controllerTextHighlighting.InitTextBox;
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

            dataGridViewFlexBison.Columns["invalidTextFlexBison"].HeaderText = LocalizationService.Get("InvalidText");
            dataGridViewFlexBison.Columns["lineColumnFlexBison"].HeaderText = LocalizationService.Get("Location");
            dataGridViewFlexBison.Columns["messageColumnFlexBison"].HeaderText = LocalizationService.Get("Message");
            dataGridViewFlexBison.Refresh();

            dataGridViewAntlr.Columns["invalidTextAntlr"].HeaderText = LocalizationService.Get("InvalidText");
            dataGridViewAntlr.Columns["lineColumnAntlr"].HeaderText = LocalizationService.Get("Location");
            dataGridViewAntlr.Columns["messageColumnAntlr"].HeaderText = LocalizationService.Get("Message");
            dataGridViewAntlr.Refresh();

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
            string text = "Список - это упорядоченная последовательность элементов\n" +
                "В данной работе элементом является константа\n" +
                "Константа - это элементы данных, значения которых известны и в процессе выполнения программы не изменяются.\n" +
                "Константой может быть:\n" +
                "\t - целое и вещественное число без знака,\n" +
                "\t - целое и вещественное число со знаком,\n" +
                "\t - строка (множество символов между одинарными кавычками)\n" +
                "\t - булевые значения (True, False)\n\n" +
                "\t Формат записи: \"имя_списка = [элементы_списка];\" \n" +
                "\t Элементы списка - это множество констат, перечисленных через запятую\n" +
                "\t Элементом списком может быть пустое множество\n" +
                "Примеры списков:\n" +
                "\t 1) a = [];\n" +
                "\t 2) a = ['Sun'];\n" +
                "\t 3) a = [1, -2, +3.4, True, False, 'str'];";

            controllerTCP.createTabPage("Постановка задачи", text);
        }

        private void grammaticMI_Click(object sender, EventArgs e)
        {
            string text = "G[Z] = {Vt, Vn, Z, P}\r\nVt = {[, ], +, -, ', A...Z, a...z, 0...9, =, _, \",\", ascii}\r\nVn = {Z,<id>, <start_list>, <end_list>, <const_int>, <const_float>, <float>, <end>, <sign>, <string>, <body_list>, <elements>, <const>, <letter>, <digit>, <digit0>, <zero>}\r\nP = {\r\nZ -> <letter><id>\r\nZ -> '_'<id>\r\n<id> -> '=' <start_list>\r\n<id> -> <letter><id>\r\n<id> -> '_' <id>\r\n<id> -> <digit><id>\r\n<start_list> -> '[' <elements>\r\n<elements> -> <digit0><const_int>\r\n<elements> -> '''<string>\r\n<elements> -> '0'<zero>\r\n<elements> -> '+' <sign>\r\n<elements> -> '-' <sign>\r\n<elements> -> 'True' <const>\r\n<elements> -> 'False' <const>\r\n<elements> -> ']' <end_list>\r\n<string> -> '''<const>\r\n<string> -> <ascii><string>\r\n<zero> -> '.'<float>\r\n<zero> -> ']' <end_list>\r\n<sign> -> '0' <zero>\r\n<sign> -> <digit0><const_int>\r\n<const_int> -> '.'<float>\r\n<const_int> -> ']'<end_list>\r\n<const_int> -> ','<body_list>\r\n<const_int> ->  <digit><const_int>\r\n<float> -> <digit> <const_float>\r\n<const_float> -> ','<body_list>\r\n<const_float> -> ']'<end_list>\r\n<const_float> -> <digit><end_list>\r\n<const> -> ','<body_list>\r\n<const> -> ']'<end_list>\r\n<body_list> -> <digit0><const_int>\r\n<body_list> -> '''<string>\r\n<body_list> -> '0'<zero>\r\n<body_list> -> '+'<sign>\r\n<body_list> -> '-'<sign>\r\n<body_list> -> 'True'<const>\r\n<body_list> -> 'False'<const>\r\n<end_list> -> ';' <end>\r\n<digit> -> '0' |'1' |'2' |'3' |'4' |'5' |'6' |'7' |'8' |'9'\r\n<digit0> ->'1' |'2' |'3' |'4' |'5' |'6' |'7' |'8' |'9' \r\n<letter> -> 'A' | 'B' ... | 'Z' | 'a' | 'b' ... | 'z'\r\n}";
            controllerTCP.createTabPage("Грамматика", text);
        }

        private void typegrammaticMI_Click(object sender, EventArgs e)
        {
            string text = "По классификации Хомского: грамматика G[Z] является автоматной (3-ий тип)";
            controllerTCP.createTabPage("Классификация грамматики", text);
        }

        private void methodAnalysisMI_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerForm));
            Image? img = (Image?)Properties.Resources.ResourceManager.GetObject("algoritm");
            controllerTCP.createTabPage("Метод анализа", "Aлгоритм синтаксического анализа: граф автоматной грамматики.", img);
        }

        private void testExampleMI_Click(object sender, EventArgs e)
        {
            string text = "a = [1, 2.023, -3, +4, True, False, 'string'];\n" +
                "1a = [];\n" +
                "b = [,];\n" +
                "c;\n" +
                "d = ['];\n" +
                "e = [;\n" +
                "f = ];\n" +
                "g = []" +
                "\nh = [];" +
                "\ntest = test;" +
                "\n = [];" +
                "\ni = [12,3,,];" +
                "\nj = [12, 3, 4,];" +
                "\n@ = [];" +
                "\nerr = [!];";
            controllerTCP.createExamplePage("Example.txt", text);
        }

        private void bibliographyMI_Click(object sender, EventArgs e)
        {
            string text = "1. Грис Д. Конструирование компиляторов для цифровых вычислительных машин / Д. Грис ; пер. с. англ. Е. Б. Докшицкой, Л. А. Зелениной, Л. Б. Морозовой, В. С. Штаркмана,  под ред. Ю. М. Баяковского, Вс. С. Штаркмана. - М., 1975. - 544 с. : табл., схемы\r\n2. Ахо А. В. Компиляторы : Принципы, технологии, инструменты / А. Ахо, Р. Сети, Д. Ульман. - М., 2003. - 768 с.\r\n3. Малявко, А. А. Формальные языки и компиляторы : учебник / Малявко А. А. - Новосибирск : Изд-во НГТУ, 2014. - 431 с. (Серия \"Учебники НГТУ\")\r\n4. Свердлов С. З. Языки программирования и методы трансляции: Учебное пособие. — 2е изд., испр. — СПб.: Издательство «Лань», 2019. — 564 с.: ил. — (Учебники для вузов. Специальная литература).\r\n5. Мозговой М. В. Классика программирования : алгоритмы, языки, автоматы, компиляторы : практический подход / Мозговой М. В. - СПб., 2006. - 320 с. : ил.";

            controllerTCP.createTabPage("Список литературы", text);
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
