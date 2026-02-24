using CompilerGUI.HelpClass;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompilerGUI.Views
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            InitializeHelpContent();

            // Подписка на событие выбора раздела
            treeView1.AfterSelect += TreeView1_AfterSelect;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeHelpContent()
        {
            treeView1.Nodes.Clear();
            var loc = LocalizationService.Get;

            TreeNode root = new TreeNode(loc("Help_Contents"));

            // Меню Файл
            TreeNode fileMenu = new TreeNode(loc("Help_MenuFile"));
            fileMenu.Nodes.Add(loc("Create"));      // уже есть в словаре
            fileMenu.Nodes.Add(loc("Open"));        // уже есть
            fileMenu.Nodes.Add(loc("Help_SaveTitle"));
            fileMenu.Nodes.Add(loc("Exit"));        // уже есть

            // Меню Правка
            TreeNode editMenu = new TreeNode(loc("Help_MenuEdit"));
            editMenu.Nodes.Add(loc("Help_UndoRedo"));
            editMenu.Nodes.Add(loc("Help_Clipboard"));
            editMenu.Nodes.Add(loc("Help_SelectionDelete"));
            editMenu.Nodes.Add(loc("Help_TextSize"));

            // Функции и окна
            TreeNode functions = new TreeNode(loc("Help_FunctionsWindows"));
            functions.Nodes.Add(loc("Help_EditArea"));
            functions.Nodes.Add(loc("Help_ResultsArea"));
            functions.Nodes.Add(loc("Help_RunCommand"));

            root.Nodes.Add(fileMenu);
            root.Nodes.Add(editMenu);
            root.Nodes.Add(functions);

            treeView1.Nodes.Add(root);
            root.ExpandAll();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var loc = LocalizationService.Get;
            string nodeText = e.Node.Text;

            // ФАЙЛ
            if (nodeText == loc("Create"))
            {
                ShowHelp(loc("Help_Create_Title"), loc("Help_Create_Content"));
            }
            else if (nodeText == loc("Open"))
            {
                ShowHelp(loc("Help_Open_Title"), loc("Help_Open_Content"));
            }
            else if (nodeText == loc("Help_SaveTitle"))
            {
                ShowHelp(loc("Help_Save_Short_Title"), loc("Help_Save_Content"));
            }
            else if (nodeText == loc("Exit"))
            {
                ShowHelp(loc("Help_Exit_Title"), loc("Help_Exit_Content"));
            }
            // ПРАВКА
            else if (nodeText == loc("Help_UndoRedo"))
            {
                ShowHelp(loc("Help_UndoRedo_Title"), loc("Help_UndoRedo_Content"));
            }
            else if (nodeText == loc("Help_Clipboard"))
            {
                ShowHelp(loc("Help_Clipboard_Title"), loc("Help_Clipboard_Content"));
            }
            else if (nodeText == loc("Help_SelectionDelete"))
            {
                ShowHelp(loc("Help_SelectionDelete_Title"), loc("Help_SelectionDelete_Content"));
            }
            else if (nodeText == loc("Help_TextSize"))
            {
                ShowHelp(loc("Help_TextSize_Title"), loc("Help_TextSize_Content"));
            }
            // ДОПОЛНИТЕЛЬНО
            else if (nodeText == loc("Help_EditArea"))
            {
                ShowHelp(loc("Help_Editor_Title"), loc("Help_Editor_Content"));
            }
            else if (nodeText == loc("Help_ResultsArea"))
            {
                ShowHelp(loc("Help_Output_Title"), loc("Help_Output_Content"));
            }
            else if (nodeText == loc("Help_RunCommand"))
            {
                ShowHelp(loc("Help_Run_Title"), loc("Help_Run_Content"));
            }
            else
            {
                richTextBox1.Text = loc("Help_Default_Content");
            }
        }

        private void ShowHelp(string title, string content)
        {
            richTextBox1.Clear();

            // Форматируем заголовок
            richTextBox1.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.AppendText(title + Environment.NewLine + Environment.NewLine);

            // Форматируем основной текст
            richTextBox1.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.AppendText(content);
        }
    }
}