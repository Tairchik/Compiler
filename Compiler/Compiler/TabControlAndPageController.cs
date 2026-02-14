using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompilerGUI
{
    public class ControllerTabControlAndPage
    {
        private bool tableIsInit = false;
        private int indexTabPage = 0;
        public TabControl tabControl;
        public delegate void TabPageInited(TabPage tabPage);
        public event TabPageInited TabPageCreate;
        public event TabPageInited TabPageChanged;
        public event Action ZoomChanged;
        public event Action<string, FileClass> TextCodeChanged;
        public event Action<string, FileClass> TabPageChangedE;


        public ControllerTabControlAndPage() 
        {
            tabControl = new TabControl();
            tabControl.SelectedIndexChanged += SelectedPageChangedHandler;
            tabControl.KeyDown += KeyDownTabPanel;
            tabControl.DragEnter += DragEnter;
            tabControl.DragDrop += DragDrop;
        }

        private void DragEnter(object sender, DragEventArgs e)
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

        private void DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                OpenFileByDrop(filePath, null);
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
                           $"Сохранить изменния в файле?\n{info.FileName}",
                           "Уведомление",
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

        private void SelectedPageChangedHandler(object sender, EventArgs e)
        {
            TabPageChanged?.Invoke(tabControl.SelectedTab);

            TabPage page = tabControl.SelectedTab;
            RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

            string code = textBox.Text;
            FileClass fileInfo = (FileClass)page.Tag;

            TabPageChangedE?.Invoke(code, fileInfo);
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

        public void OpenFile(Control parentPanel) 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            FileClass fileInfo = new FileClass("", "", true);
            
            openFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = $"Открыть файл";
            openFileDialog.DefaultExt = $"{fileInfo.Ext}";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string text = File.ReadAllText(openFileDialog.FileName);
                    if (text == null) throw new Exception("Ошибка чтения");

                    fileInfo.FilePath = openFileDialog.FileName;
                    fileInfo.FileName = Path.GetFileName(openFileDialog.FileName);
                    fileInfo.IsSaved = true;

                    TabPage page = createTabPage(fileInfo);

                    if (tableIsInit == false)
                    {
                        indexTabPage = 1;
                        tabControl.Dock = DockStyle.Fill;
                        tabControl.Name = "tabControl";
                        tableIsInit = true;
                        parentPanel.Controls.Add(tabControl);
                        tabControl.Controls.Add(page);
                        tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                        TabPageCreate?.Invoke(tabControl.SelectedTab);
                    }
                    else
                    {
                        indexTabPage++;
                        tabControl.Controls.Add(page);
                        tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                        TabPageCreate?.Invoke(tabControl.SelectedTab);
                    }

                    RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

                    textBox.Text = text;
                    fileInfo.IsSaved = true;
                    page.Text = fileInfo.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveFile(TabPage tabPage) 
        {
            TabPage page = tabPage;

            FileClass fileInfo = (FileClass)page.Tag;
            RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

            if (fileInfo.FilePath == "" && fileInfo.IsSaved == false)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = $"Сохранить файл";
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
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
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
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveFile() 
        {
            TabPage page = tabControl.SelectedTab;
            
            if (page == null) 
            {
                MessageBox.Show(
                    "Выберите файл, чтобы сохранить",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                );
                return;
            }

            FileClass fileInfo = (FileClass)page.Tag;
            RichTextBox textBox = (RichTextBox) page.Controls.Find("richTextBoxText", true)[0];

            if (fileInfo.FilePath == "" && fileInfo.IsSaved == false) 
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = $"Текстовые файлы (*.{fileInfo.Ext})|*.{fileInfo.Ext}|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = $"Сохранить файл";
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
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
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
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
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
                    "Выберите файл, чтобы сохранить",
                    "Предупреждение",
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
            saveFileDialog.Title = $"Сохранить файл";
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
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CreateFileBtnClick(Control parentPanel) 
        {
            if (tableIsInit == false) 
            {
                indexTabPage = 1;
                parentPanel.Controls.Add(tabControl);
                tabControl.Dock = DockStyle.Fill;
                tabControl.Name = "tabControl";
                TabPage tabPage = createTabPage();
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                tabControl.Controls.Add(tabPage);
                tableIsInit = true;
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

        public void CreateFileBtnClick(Control parentPanel, FileClass fileInfo)
        {
            if (tableIsInit == false)
            {
                indexTabPage = 1;
                parentPanel.Controls.Add(tabControl);
                TabPage tabPage = createTabPage();
                tabControl.Dock = DockStyle.Fill;
                tabControl.Name = "tabControl";
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                tabPage.Tag = fileInfo;
                tabPage.Text = fileInfo.FileName;
                tableIsInit = true;
                tabControl.Controls.Add(tabPage);
                TabPageCreate?.Invoke(tabControl.SelectedTab);
            }
            else
            {
                indexTabPage++;
                TabPage tabPage = createTabPage();
                tabPage.Tag = fileInfo;
                tabPage.Text = fileInfo.FileName;
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                tabControl.Controls.Add(tabPage);
                TabPageCreate?.Invoke(tabControl.SelectedTab);
            }
        }

        public void OpenFileByDrop(string filePath, Control parentPanel) 
        {
            FileClass fileInfo = new FileClass("", "", true);
            try
            {
                string text = File.ReadAllText(filePath);
                if (text == null) throw new Exception("Ошибка чтения");

                fileInfo.FilePath = filePath;
                fileInfo.FileName = Path.GetFileName(filePath);
                fileInfo.IsSaved = true;

                CreateFileBtnClick(parentPanel);

                TabPage page = tabControl.SelectedTab;
                RichTextBox textBox = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];

                page.Tag = fileInfo;
                textBox.Text = text;
                fileInfo.IsSaved = true;
                page.Text = fileInfo.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void KeyDownTabPanel(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control) && Control.ModifierKeys.HasFlag(Keys.Shift))
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveUsFile();
                }
            }
            else if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.O)
                {
                    OpenFile(null);
                }
                else if (e.KeyCode == Keys.N)
                {
                    CreateFileBtnClick(null);
                }
                else if (e.KeyCode == Keys.S)
                {
                    SaveFile();
                }
            }
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
                       $"Сохранить изменния в файле?\n{info.FileName}",
                       "Уведомление",
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
                tableIsInit = false;
                tabControl.Parent.Controls.Remove(tabControl);
            }
            return true;
        }

        private bool ChangeZoomText(float size)
        {
            TabPage page = tabControl.SelectedTab;

            RichTextBox richTextBoxText = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];
            RichTextBox richTextBoxNumbers = (RichTextBox)page.Controls.Find("richTextBoxNumbers", true)[0];


            if (richTextBoxText == null) return false;

            richTextBoxText.ZoomFactor += size;
            richTextBoxNumbers.ZoomFactor += size;
            return true;
        }

        private void RichTextBoxText_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                TabPage page = tabControl.SelectedTab;

                RichTextBox richTextBoxText = (RichTextBox)page.Controls.Find("richTextBoxText", true)[0];
                RichTextBox richTextBoxNumbers = (RichTextBox)page.Controls.Find("richTextBoxNumbers", true)[0];

                if (richTextBoxText != null)
                {
                    float newZoom = richTextBoxText.ZoomFactor;
                    if (e.Delta > 0)
                        newZoom += 0.1f;
                    else
                        newZoom -= 0.1f;

                    newZoom = Math.Max(0.1f, Math.Min(5f, newZoom));
                    richTextBoxNumbers.ZoomFactor = newZoom;
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
            richTextBoxNumbers.Font = new Font("Segoe UI", 14F);
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
            richTextBoxText.Font = new Font("Segoe UI", 14F);
            richTextBoxText.Name = "richTextBoxText";
            richTextBoxText.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBoxText.Size = new Size(716, 426);
            richTextBoxText.TabIndex = 1;
            richTextBoxText.Text = "";
            richTextBoxText.WordWrap = false;
            richTextBoxText.DragDrop += DragDrop;
            richTextBoxText.DragEnter += DragEnter;
            richTextBoxText.AllowDrop = true;

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

            tabPage.Controls.Add(tableLayoutPanel);
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
            
            return tabPage;
        }
    }
}
