using CompilerGUI.Controllers;
using CompilerGUI.HelpClass;
using CompilerGUI.Properties;
using CompilerGUI.Views;
using System.Diagnostics;
using System.Media;
using System.Security.Policy;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace CompilerGUI
{
    public partial class CompilerForm : Form
    {
        private TabPagesController controllerTCP;
        private SyncRedactorTextController controllerRichTB;
        private KeyController keyController;
        private BindingList<RegexMatchResult> regexMatchResults = new BindingList<RegexMatchResult>();

        public CompilerForm()
        {
            InitializeComponent();
            ApplyLocalization();
            toolStripComboBox.SelectedIndex = 0;
            dataGridView.DataSource = regexMatchResults;
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            this.AllowDrop = true;
            mainPanel.AllowDrop = true;
            keyController = new KeyController();
            controllerTCP = new TabPagesController(mainPanel.Panel1);
            controllerRichTB = new SyncRedactorTextController();

            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerTCP.ZoomChanged += controllerRichTB.UpdateColumnWidth;
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
        }

        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            controllerTCP.FocusToEditor(regexMatchResults[e.RowIndex].AbsoluteIndex, regexMatchResults[e.RowIndex].PositionEnd, regexMatchResults[e.RowIndex].PositionStart);
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

            (string, bool) res = controllerTCP.GetTextEditor();
            if (res.Item2 != false)
            {
                RegexProcessor processor = new RegexProcessor();
                List<RegexMatchResult> result = processor.Process(res.Item1, toolStripComboBox.SelectedIndex);
                dataGridView.Rows.Clear();
                controllerTCP.Console.Clear();

                int count = 0;
                foreach (var i in result) 
                {
                    regexMatchResults.Add(i);
                    count++;
                }

                controllerTCP.Console.Text = $"Количество совпадений: {count}";
            }
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
            (string, bool) res = controllerTCP.GetTextEditor();
            if (res.Item2 != false)
            {
                RegexProcessor processor = new RegexProcessor();
                List<RegexMatchResult> result = processor.Process(res.Item1, toolStripComboBox.SelectedIndex);
                dataGridView.Rows.Clear();
                controllerTCP.Console.Clear();

                int count = 0;
                foreach (var i in result)
                {
                    regexMatchResults.Add(i);
                    count++;
                }

                controllerTCP.Console.Text = $"Количество совпадений: {count}";
            }
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
          
        }

        private void AboutProgramMI_Click(object sender, EventArgs e)
        {
            openReadMe();
        }

        private void openTSB_Click(object sender, EventArgs e)
        {
            controllerTCP.OpenFile();
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
