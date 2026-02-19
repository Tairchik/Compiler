using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CompilerGUI.Controllers
{
    public class SyncRedactorTextController
    {
        private RichTextBox richTextBoxText;
        private RichTextBox richTextBoxNumbers;
        private TableLayoutPanel tableLayoutPanel;
        public event Action TextIsChange;
        private int lastLineCount;
        
        public void init(TabPage tabPape) 
        {
            tableLayoutPanel = (TableLayoutPanel) tabPape.Controls.Find("tableLayoutPanel", true)[0];
            richTextBoxNumbers = (RichTextBox)tableLayoutPanel.Controls["richTextBoxNumbers"];
            richTextBoxText = (RichTextBox)tableLayoutPanel.Controls["richTextBoxText"];
            lastLineCount = 0;
            UpdateColumnWidth();
            SetupLineNumbers();
        }

        public void pageChached(TabPage tabPape) 
        {
            if (tabPape == null) return;
            tableLayoutPanel = (TableLayoutPanel)tabPape.Controls.Find("tableLayoutPanel", true)[0];
            richTextBoxNumbers = (RichTextBox)tableLayoutPanel.Controls["richTextBoxNumbers"];
            richTextBoxText = (RichTextBox)tableLayoutPanel.Controls["richTextBoxText"];
            lastLineCount = GetLineCount(richTextBoxText);
            HighlightCurrentLine();
            richTextBoxText.Focus();

        }

        private void SetupLineNumbers()
        {
            richTextBoxText.TextChanged += RichTextBoxTextCode_TextChanged;
            richTextBoxText.VScroll += RichTextBoxTextCode_VScroll;
            richTextBoxText.SelectionChanged += RichTextBoxTextCode_SelectionChanged;
            richTextBoxNumbers.VScroll += RichTextBoxNumbers_VScroll;
            UpdateLineNumbers();
            HighlightCurrentLine();
            richTextBoxText.Focus();

        }

        public bool UndoText() 
        {
            if (richTextBoxText == null) return false;

            richTextBoxText.Undo();
            return true;
        }
        public bool RedoText()
        {
            if (richTextBoxText == null) return false;

            richTextBoxText.Redo();
            return true;
        }
        public string GetSelectedText() 
        {
            if (richTextBoxText != null)
            {
                return richTextBoxText.SelectedText;
            }
            else 
            {
                return string.Empty;
            }
        }

        public bool InsertText() 
        {
            if (richTextBoxText == null) return false;
            richTextBoxText.Paste();

            return true;
        }

        public bool SelectAllText() 
        {
            if (richTextBoxText != null)
            {
                richTextBoxText.SelectAll();
                return true;
            }
            return false;
        }

        public string GetSelectedTextAndCut()
        {
            if (richTextBoxText != null)
            {
                string res = richTextBoxText.SelectedText;
                richTextBoxText.SelectedText = string.Empty;
                return res;
            }
            else
            {
                return string.Empty;
            }            
        }

        public bool DeleteSelectedText()
        {
            if (richTextBoxText != null)
            {
                if (string.IsNullOrEmpty(richTextBoxText.SelectedText)) return false;
                richTextBoxText.SelectedText = string.Empty;
                return true;
            }
            return false;
        }

        private void RichTextBoxTextCode_TextChanged(object sender, EventArgs e)
        {
            UpdateLineNumbers();
            TextIsChange?.Invoke();
        }

        private void RichTextBoxTextCode_VScroll(object sender, EventArgs e)
        {
            SyncScrollPositions();
        }

        private void RichTextBoxNumbers_VScroll(object sender, EventArgs e)
        {
            SyncScrollPositions();
        }

        private void RichTextBoxTextCode_SelectionChanged(object sender, EventArgs e)
        {
            HighlightCurrentLine();
        }

        private void UpdateLineNumbers()
        {
            try
            {
                int lineCount = GetLineCount(richTextBoxText);

                if (lineCount == lastLineCount)
                    return;

                lastLineCount = lineCount;

                StringBuilder sb = new StringBuilder();

                int maxDigits = lineCount.ToString().Length;

                for (int i = 1; i <= lineCount; i++)
                {
                    string lineNumber = i.ToString().PadLeft(maxDigits);
                    sb.AppendLine(lineNumber);
                }

                richTextBoxNumbers.Text = sb.ToString();

                UpdateColumnWidth();
                HighlightCurrentLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении номеров строк: {ex.Message}");
            }
        }

        private int GetLineCount(RichTextBox rtb)
        {
            if (string.IsNullOrEmpty(rtb.Text))
                return 1;

            return rtb.GetLineFromCharIndex(rtb.TextLength) + 1;
        }

        private void HighlightCurrentLine()
        {
            try
            {
                int currentLine = richTextBoxText.GetLineFromCharIndex(richTextBoxText.SelectionStart) + 1;

                richTextBoxNumbers.SelectAll();
                richTextBoxNumbers.SelectionAlignment = HorizontalAlignment.Center;
                richTextBoxNumbers.SelectionBackColor = SystemColors.Control;
                richTextBoxNumbers.SelectionColor = Color.Gray;

                if (currentLine <= lastLineCount && currentLine > 0)
                {
                    int start = richTextBoxNumbers.GetFirstCharIndexFromLine(currentLine - 1);
                    if (start >= 0)
                    {
                        int length = richTextBoxNumbers.Lines.Length > currentLine - 1 ?
                                    richTextBoxNumbers.Lines[currentLine - 1].Length : 0;

                        if (start + length <= richTextBoxNumbers.TextLength)
                        {
                            richTextBoxNumbers.Select(start, length);
                            richTextBoxNumbers.SelectionColor = Color.DarkCyan;
                            richTextBoxNumbers.SelectionFont = new Font(
                                richTextBoxNumbers.Font,
                                FontStyle.Bold
                            );
                        }
                    }
                }

            }
            catch
            {
                
            }
        }

        public void UpdateColumnWidth()
        {
            if (tableLayoutPanel == null || richTextBoxNumbers == null || richTextBoxText == null)
                return;

            int lineCount = GetLineCount(richTextBoxText);
            int maxDigits = lineCount.ToString().Length;

            float charWidth = richTextBoxNumbers.ZoomFactor * 10;
            float columnWidth = charWidth * (5 + maxDigits);
            tableLayoutPanel.ColumnStyles[0].Width = columnWidth;
        }

        // Импорты WinAPI для синхронизации прокрутки
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x0115;
        private const int EM_GETSCROLLPOS = 0x04DD;
        private const int EM_SETSCROLLPOS = 0x04DE;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        private void SyncScrollPositions()
        {
            try
            {
                POINTAPI scrollPos = GetScrollPosition(richTextBoxText.Handle);
                SetScrollPosition(richTextBoxNumbers.Handle, scrollPos);
            }
            catch
            {

            }
        }

        private POINTAPI GetScrollPosition(IntPtr hWnd)
        {
            POINTAPI point = new POINTAPI();
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(point));
            try
            {
                SendMessage(hWnd, EM_GETSCROLLPOS, IntPtr.Zero, ptr);
                point = Marshal.PtrToStructure<POINTAPI>(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return point;
        }

        private void SetScrollPosition(IntPtr hWnd, POINTAPI point)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(point));
            try
            {
                Marshal.StructureToPtr(point, ptr, false);
                SendMessage(hWnd, EM_SETSCROLLPOS, IntPtr.Zero, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        
    }
}
