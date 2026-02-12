using System.Media;

namespace CompilerGUI
{
    public partial class CompilerForm : Form
    {
        private TabControlAndPageController controllerTCP;
        private ControllerRichTB controllerRichTB;
        public CompilerForm()
        {
            InitializeComponent();
            controllerTCP = new TabControlAndPageController();
            controllerRichTB = new ControllerRichTB();
            controllerTCP.TabPageCreate += controllerRichTB.init;
            controllerTCP.TabPageChanged += controllerRichTB.pageChached;
            controllerRichTB.TextIsChange += controllerTCP.UpdatePageInfo;
            this.FormClosing += exit_Process;


        }

        private void createFile_Click(object sender, EventArgs e)
        {
            controllerTCP.CreateFileBtnClick(mainPanel);
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
            controllerTCP.OpenFile(mainPanel);
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

        }

        private void aboutMI_Click(object sender, EventArgs e)
        {

        }

        private void SettingsMI_Click(object sender, EventArgs e)
        {

        }
    }
}
