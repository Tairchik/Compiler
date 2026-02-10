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
    }
}
