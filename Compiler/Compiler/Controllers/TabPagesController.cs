using CompilerGUI.HelpClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompilerGUI.Controllers
{
    public class TabPagesController
    {
        private int indexTabPage = 0;
        public TabControl tabControl;
        public delegate void TabPageInited(TabPage tabPage);
        public event TabPageInited TabPageCreate;
        public event TabPageInited TabPageChanged;
        public event Action ZoomChanged;
        public event Action<string, FileClass> TextCodeChanged;
        public event Action<string, FileClass> TabPageChangedE;
        public event Action<Keys> TapPageKeyDown;

        public TabPagesController(Control parentPanel) 
        {
            initTabControl(parentPanel);
            tabControl.SelectedIndexChanged += SelectedPageChangedHandler;
            tabControl.KeyDown += KeyDownTabPanel;
            tabControl.DragEnter += DragEnter;
            tabControl.DragDrop += DragDrop;
        }

        private void initTabControl(Control parentPanel) 
        {
            tabControl = new TabControl();
            parentPanel.Controls.Add(tabControl);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Name = "tabControl";
            tabControl.Visible = tabControl.TabCount == 0 ? false : true;
        }

        public void CreateFile(FileClass? fileInfo = null)
        {
            tabControl.Visible = true;
            indexTabPage = tabControl.TabCount + 1;
            TabPage tabPage = createTabPage();

            if (fileInfo != null)
            {
                tabPage.Tag = fileInfo;
                tabPage.Text = fileInfo.FileName;
            }

            TabPageCreate?.Invoke(tabControl.SelectedTab);
        }

        public void OpenFile(string filePath = "")
        {
            FileClass fileInfo = new FileClass("", "", true);
            DialogResult result = DialogResult.OK;
            if (string.IsNullOrEmpty(filePath)) 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = $"{LocalizationService.Get("OpenFileTitle")}";
                openFileDialog.DefaultExt = $"{fileInfo.Ext}";
                result = openFileDialog.ShowDialog();
                fileInfo.FilePath = openFileDialog.FileName;
                fileInfo.FileName = Path.GetFileName(openFileDialog.FileName);
            }
            else 
            {
                fileInfo.FilePath = filePath;
                fileInfo.FileName = Path.GetFileName(filePath);
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    string text = File.ReadAllText(fileInfo.FilePath);
                    if (text == null) throw new Exception(LocalizationService.Get("ErrorRead"));
                    
                    tabControl.Visible = true;
                    fileInfo.IsSaved = true;
                    TabPage tabPage = createTabPage(fileInfo);
                    RichTextBox textBox = (RichTextBox)tabPage.Controls.Find("richTextBoxText", true)[0];

                    textBox.Text = text;
                    fileInfo.IsSaved = true;
                    tabPage.Text = fileInfo.FileName;
                    TabPageCreate?.Invoke(tabControl.SelectedTab);

                    if (tabControl.TabCount == 1) 
                    {
                        TabPageChanged?.Invoke(tabControl.SelectedTab);
                        TabPageChangedE?.Invoke(text, fileInfo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{LocalizationService.Get("ErrorOpenMessage")}: {ex.Message}", LocalizationService.Get("Error"),
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveFile(TabPage? tabPage = null)
        {
            TabPage? page = tabPage == null ? tabControl.SelectedTab : tabPage;

            if (page == null)
            {
                MessageBox.Show(
                    LocalizationService.Get("NotificationSavingFile"),
                    LocalizationService.Get("Warning"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                );
                return;
            }

            FileClass fileInfo = (FileClass)page.Tag;
            RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

            if (fileInfo.FilePath == "" && fileInfo.IsSaved == false)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = LocalizationService.Get("SaveFileTitle");
                saveFileDialog.DefaultExt = $"{fileInfo.Ext}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                        fileInfo.FileName = Path.GetFileName(saveFileDialog.FileName);
                        fileInfo.IsSaved = true;
                        fileInfo.FilePath = saveFileDialog.FileName;
                        page.Text = fileInfo.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{LocalizationService.Get("ErrorSaveMessage")}: {ex.Message}", LocalizationService.Get("Error"),
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (fileInfo.IsSaved == false)
            {
                try
                {
                    File.WriteAllText(fileInfo.FilePath, textBox.Text);
                    page.Text = fileInfo.FileName;
                    fileInfo.IsSaved = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{LocalizationService.Get("ErrorSaveMessage")}: {ex.Message}", LocalizationService.Get("Error"),
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveUsFile()
        {
            TabPage page = tabControl.SelectedTab;

            if (page == null)
            {
                MessageBox.Show(
                    LocalizationService.Get("NotificationSavingFile"),
                    LocalizationService.Get("Warning"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                );
                return;
            }

            FileClass fileInfo = (FileClass)page.Tag;
            RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = LocalizationService.Get("SaveFileTitle");
            saveFileDialog.DefaultExt = $"{fileInfo.Ext}";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                    if (fileInfo.FilePath == "")
                    {
                        fileInfo.FileName = Path.GetFileName(saveFileDialog.FileName);
                        fileInfo.IsSaved = true;
                        fileInfo.FilePath = saveFileDialog.FileName;
                        page.Text = fileInfo.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{LocalizationService.Get("ErrorSaveMessage")}: {ex.Message}", LocalizationService.Get("Error"),
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DragEnter(object? sender, DragEventArgs e)
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

        private void DragDrop(object? sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                OpenFile(filePath);
            }
        }

        public bool Exit(Form view) 
        {
            FileClass info;

            foreach (TabPage tabPage in tabControl.TabPages) 
            {
                info = (FileClass) tabPage.Tag;
                if (info.IsSaved == false) 
                {
                    DialogResult result = MessageBox.Show(
                           $"{LocalizationService.Get("SaveChangeInFile")}?\n{info.FileName}",
                           LocalizationService.Get("Notification"),
                           MessageBoxButtons.YesNoCancel,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1
                    );
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        SaveFile(tabPage);
                    }
                }
            }
            return true;
        }

        private void SelectedPageChangedHandler(object? sender, EventArgs e)
        {
            if (tabControl != null && tabControl.SelectedTab != null) 
            {
                TabPageChanged?.Invoke(tabControl.SelectedTab);

                TabPage page = tabControl.SelectedTab;
                RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

                string code = textBox.Text;
                TabPageChangedE?.Invoke(code, (FileClass)page.Tag);
            }
        }

        public void UpdatePageInfo() 
        {
            TabPage page = tabControl.SelectedTab;
            FileClass fileInfo = (FileClass)page.Tag;

            RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];
            string code = textBox.Text;

            TextCodeChanged?.Invoke(code, fileInfo);
            if (fileInfo.IsSaved == false) return;
            
            fileInfo.IsSaved = false;
            page.Text = $"{fileInfo.FileName}*";
        }

        private void KeyDownTabPanel(object? sender, KeyEventArgs e)
        {
            TapPageKeyDown?.Invoke(e.KeyCode);
        }

        public bool CloseTabe()
        {
            if (tabControl == null) return false;

            TabPage page = tabControl.SelectedTab;
            if (page == null) return false;

            FileClass info = (FileClass) page.Tag;


            if (info.IsSaved == false)
            {
                DialogResult result = MessageBox.Show(
                       $"{LocalizationService.Get("SaveChangeInFile")}?\n{info.FileName}",
                       LocalizationService.Get("Notification"),
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1
                );
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
                else if (result == DialogResult.Yes)
                {
                    SaveFile(page);
                }
            }
       
            page.Controls.Clear();
            tabControl.TabPages.Remove(page);
            if (tabControl.TabPages.Count == 0) 
            {
                tabControl.Visible = false;
            }
            return true;
        }

        private bool ChangeZoomText(float size)
        {
            TabPage page = tabControl.SelectedTab;

            RichTextBox richTextBoxText = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];
            RichTextBox richTextBoxNumbers = (RichTextBox)page.Controls.Find("richTextBoxNumbers", true)[0];
            RichTextBox richTextBoxOut = (RichTextBox)page.Controls.Find("richTextBoxOut", true)[0];

            if (richTextBoxText == null) return false;

            richTextBoxText.ZoomFactor += size;
            richTextBoxNumbers.ZoomFactor += size;
            richTextBoxOut.ZoomFactor += size;

            return true;
        }

        private void RichTextBoxText_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                TabPage page = tabControl.SelectedTab;

                RichTextBox richTextBoxText = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];
                RichTextBox richTextBoxNumbers = (RichTextBox)page.Controls.Find("richTextBoxNumbers", true)[0];
                RichTextBox richTextBoxOut = (RichTextBox)page.Controls.Find("richTextBoxOut", true)[0];


                if (richTextBoxText != null)
                {
                    float newZoom = richTextBoxText.ZoomFactor;
                    if (e.Delta > 0)
                        newZoom += 0.1f;
                    else
                        newZoom -= 0.1f;

                    newZoom = Math.Max(0.1f, Math.Min(5f, newZoom));

                    if (sender == richTextBoxText) 
                    {
                        richTextBoxNumbers.ZoomFactor = newZoom;
                        richTextBoxOut.ZoomFactor = newZoom;
                    }
                    else if (sender == richTextBoxOut) 
                    {
                        richTextBoxNumbers.ZoomFactor = newZoom;
                        richTextBoxText.ZoomFactor = newZoom;
                    }
                }
            }
        }

        private void RichTextBoxText_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Add:
                        case Keys.Oemplus:
                            ChangeZoomText(+0.1f);
                            e.SuppressKeyPress = true;
                            e.Handled = true;
                            break;

                        case Keys.Subtract:
                        case Keys.OemMinus:
                            ChangeZoomText(-0.1f);
                            e.SuppressKeyPress = true;
                            e.Handled = true;
                            break;
                    }
                    ZoomChanged?.Invoke();
                }
            }
        }

        private TabPage createTabPage(FileClass? fileInfo = null) 
        {
            TabPage tabPage = new TabPage();
            SplitContainer splitContainer = new SplitContainer();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            RichTextBox richTextBoxNumbers = new RichTextBox();
            RichTextBox richTextBoxText = new RichTextBox();
            Panel panel2 = new Panel();
            RichTextBox richTextBoxOut = new RichTextBox();

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
            richTextBoxNumbers.Font = new Font("Segoe UI", 12F);
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
            richTextBoxText.KeyDown += RichTextBoxText_KeyDown;
            richTextBoxText.MouseWheel += RichTextBoxText_MouseWheel;
            richTextBoxText.Dock = DockStyle.Fill;
            richTextBoxText.Location = new Point(60, 0);
            richTextBoxText.Margin = new Padding(0);
            richTextBoxText.Font = new Font("Segoe UI", 12F);
            richTextBoxText.Name = "richTextBoxText";
            richTextBoxText.Size = new Size(716, 426);
            richTextBoxText.TabIndex = 1;
            richTextBoxText.Text = "";
            richTextBoxText.WordWrap = false;
            richTextBoxText.DragDrop += DragDrop;
            richTextBoxText.DragEnter += DragEnter;
            richTextBoxText.AllowDrop = true;

            richTextBoxOut.BorderStyle = BorderStyle.None;
            richTextBoxOut.KeyDown += RichTextBoxText_KeyDown;
            richTextBoxOut.MouseWheel += RichTextBoxText_MouseWheel;
            richTextBoxOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxOut.BackColor = Color.White;
            richTextBoxOut.ForeColor = Color.Black;
            richTextBoxOut.ReadOnly = false;
            richTextBoxOut.Location = new Point(4, 0);
            richTextBoxOut.Margin = new Padding(0);
            richTextBoxOut.Font = new Font("Segoe UI", 12F);
            richTextBoxOut.Name = "richTextBoxOut";
            richTextBoxOut.Size = new Size(142, 42);
            richTextBoxOut.TabIndex = 1;
            richTextBoxOut.Text = ">";
            richTextBoxOut.WordWrap = false;
            richTextBoxOut.DragDrop += DragDrop;
            richTextBoxOut.DragEnter += DragEnter;
            richTextBoxOut.AllowDrop = true;

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
            splitContainer.BackColor = Color.DarkGray;
            splitContainer.Location = new Point(3, 3);
            splitContainer.Name = $"splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            splitContainer.Panel1.Controls.Add(tableLayoutPanel);
            splitContainer.Panel2.Controls.Add(richTextBoxOut);
            splitContainer.Size = new Size(954, 347);
            splitContainer.SplitterDistance = 189;

            tabPage.Controls.Add(splitContainer);
            tabPage.Location = new Point(4, 24);
            tabPage.Name = $"tabPage{indexTabPage}";
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(960, 353);
            tabPage.TabIndex = indexTabPage;
            tabPage.Text = $"New File ({indexTabPage})*";
            tabPage.UseVisualStyleBackColor = true;
            
            if (fileInfo == null) 
            {
                fileInfo = new FileClass(tabPage.Text, "", false);
            }

            tabPage.Tag = fileInfo;

            tabControl.Controls.Add(tabPage);
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;

            return tabPage;
        }
    }
}
