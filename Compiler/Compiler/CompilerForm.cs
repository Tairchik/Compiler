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
        }

        private void createFile_Click(object sender, EventArgs e)
        {
            controllerTCP.CreateFileBtnClick(mainPanel);
        }
    }
}
