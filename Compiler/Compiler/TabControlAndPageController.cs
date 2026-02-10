using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerGUI
{
    public class TabControlAndPageController
    {
        private bool tableIsInit = false;
        private int indexTabPage = 0;
        public TabControl tabControl;
        public delegate void TabPageInited(TabPage tabPage);
        public event TabPageInited TabPageCreate;
        public event TabPageInited TabPageChanged;

        public TabControlAndPageController() 
        {
            tabControl = new TabControl();
            tabControl.SelectedIndexChanged += SelectedPageChangedHandler;
        }

        private void SelectedPageChangedHandler(object sender, EventArgs e)
        {
            TabPageChanged?.Invoke(tabControl.SelectedTab);
        }

        public void CreateFileBtnClick(Control parentPanel) 
        {
            if (tableIsInit == false) 
            {
                indexTabPage = 1;
               
                TabPage tabPage = createTabPage();

                tabControl.Dock = DockStyle.Fill;
                tabControl.Name = "tabControl";
                tabControl.Controls.Add(tabPage);
                tableIsInit = true;
                parentPanel.Controls.Add(tabControl);
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                TabPageCreate?.Invoke(tabControl.SelectedTab);
            }
            else
            {
                indexTabPage++;
                TabPage tabPage = createTabPage();
                tabControl.Controls.Add(tabPage);
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                TabPageCreate?.Invoke(tabControl.SelectedTab);
            }
        } 

        private TabPage createTabPage() 
        {
            TabPage tabPage = new TabPage();
            SplitContainer splitContainer = new SplitContainer();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            RichTextBox richTextBoxNumbers = new RichTextBox();
            RichTextBox richTextBoxText = new RichTextBox();
            Panel panel2 = new Panel();

            panel2.BackColor = SystemColors.Window;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(50, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 426);
            panel2.TabIndex = 2;

            richTextBoxNumbers.BorderStyle = BorderStyle.None;
            richTextBoxNumbers.Dock = DockStyle.Fill;
            richTextBoxNumbers.Enabled = false;
            richTextBoxNumbers.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBoxNumbers.Location = new Point(0, 0);
            richTextBoxNumbers.Margin = new Padding(0);
            richTextBoxNumbers.Name = "richTextBoxNumbers";
            richTextBoxNumbers.ReadOnly = true;
            richTextBoxNumbers.ScrollBars = RichTextBoxScrollBars.None;
            richTextBoxNumbers.Size = new Size(50, 426);
            richTextBoxNumbers.TabIndex = 0;
            richTextBoxNumbers.TabStop = false;
            richTextBoxNumbers.Text = "";
            richTextBoxNumbers.WordWrap = false;

            richTextBoxText.BorderStyle = BorderStyle.None;
            richTextBoxText.Dock = DockStyle.Fill;
            richTextBoxText.Location = new Point(60, 0);
            richTextBoxText.Margin = new Padding(0);
            richTextBoxText.Name = "richTextBoxText";
            richTextBoxText.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBoxText.Size = new Size(716, 426);
            richTextBoxText.TabIndex = 1;
            richTextBoxText.Text = "";
            richTextBoxText.WordWrap = false;

            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(richTextBoxNumbers, 0, 0);
            tableLayoutPanel.Controls.Add(richTextBoxText, 2, 0);
            tableLayoutPanel.Controls.Add(panel2, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(776, 426);
            tableLayoutPanel.TabIndex = 0;

            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(3, 3);
            splitContainer.Name = $"splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;

            splitContainer.Panel1.Controls.Add(tableLayoutPanel);
            splitContainer.Size = new Size(954, 347);
            splitContainer.SplitterDistance = 189;

            tabPage.Controls.Add(splitContainer);
            tabPage.Location = new Point(4, 24);
            tabPage.Name = $"tabPage{indexTabPage}";
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(960, 353);
            tabPage.TabIndex = indexTabPage;
            tabPage.Text = $"New File ({indexTabPage})";
            tabPage.UseVisualStyleBackColor = true;

            return tabPage;
        }


    }
}
