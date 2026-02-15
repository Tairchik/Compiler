using System.Media;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CompilerGUI
{
    public partial class CompilerForm : Form
    {
        private ControllerTabControlAndPage controllerTCP;
        private ControllerRichTB controllerRichTB;
        private ControllerExceptionsCode controllerExceptionsCode;
        private ControllerConsole controllerConsole;
        private ControllerTextHighlighting controllerTextHighlighting;
        public CompilerForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            mainPanel.AllowDrop = true;
            controllerTCP = new ControllerTabControlAndPage();
            controllerExceptionsCode = new ControllerExceptionsCode(this.dataGridView);
            controllerRichTB = new ControllerRichTB();
            controllerConsole = new ControllerConsole();
            controllerTextHighlighting = new ControllerTextHighlighting("txt");
            mainPanel.KeyDown += keyPressedMainForm;
            this.KeyDown += keyPressedMainForm;
            this.FormClosing += exit_Process;
            this.DragEnter += CompilerForm_DragEnter;
            this.DragDrop += CompilerForm_DragDrop;
            mainPanel.DragDrop += CompilerForm_DragDrop;
            mainPanel.DragEnter += CompilerForm_DragEnter;

            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerTCP.ZoomChanged += controllerRichTB.UpdateColumnWidth;

            controllerRichTB.TextIsChange += controllerTCP.UpdatePageInfo;

            controllerTCP.TextCodeChanged += controllerExceptionsCode.TextCodeChanged;
            controllerTCP.TabPageChangedE += controllerExceptionsCode.PageCodeChanged;

            controllerTCP.TabPageChanged += controllerConsole.InitCodeTextBox;

            controllerTCP.TabPageChanged += controllerTextHighlighting.InitTextBox;
            controllerTCP.TabPageCreate += controllerTextHighlighting.InitTextBox;
            controllerRichTB.TextIsChange += controllerTextHighlighting.HighlightCode;
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
                controllerTCP.OpenFileByDrop(filePath, mainPanel.Panel1);
            }
        }

        private void keyPressedMainForm(object sender, KeyEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.O)
                {
                    controllerTCP.OpenFile(mainPanel.Panel1);
                }
                else if (e.KeyCode == Keys.N)
                {
                    controllerTCP.CreateFileBtnClick(mainPanel.Panel1);
                }
            }
        }

        private void createFile_Click(object sender, EventArgs e)
        {
            controllerTCP.CreateFileBtnClick(mainPanel.Panel1);
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
            controllerTCP.OpenFile(mainPanel.Panel1);
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

        }

        private void deleteTabTSB_Click(object sender, EventArgs e)
        {
            controllerTCP.CloseTabe();
        }
    }
}
