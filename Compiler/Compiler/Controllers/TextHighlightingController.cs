using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CompilerGUI.HelpClass;

namespace CompilerGUI.Controllers
{
    public class TextHighlightingController
    {
        private string previousText = "";
        private string formatCode = "";
        private KeyWordFashionList keys;
        public RichTextBox codeTextBox;
        private Dictionary<string, Dictionary<Color, string[]>> dict = new Dictionary<string, Dictionary<Color, string[]>>()
        {
            ["txt"] = new Dictionary<Color, string[]> {
                [Color.Blue] = ["int", "float", "double"],
                [Color.Black] = ["@BASE@"],
            },
            ["base"] = new Dictionary<Color, string[]> { [Color.Black] = ["@BASE@"] }
        };

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x0b;

        public TextHighlightingController(string formatCode)
        {
            this.formatCode = formatCode;
            var result = new Dictionary<Color, string[]>();
            if (dict.TryGetValue(formatCode, out result))
            {
                keys = new KeyWordFashionList(dict[formatCode]);
            }
            else
            {
                formatCode = "base";
                keys = new KeyWordFashionList(dict[formatCode]);
            }
        }

        public void InitTextBox(TabPage tabPape)
        {
            if (tabPape == null) return;
            var tableLayoutPanel = (TableLayoutPanel)tabPape.Controls.Find("tableLayoutPanel", true)[0];
            var found = tableLayoutPanel.Controls["richTextBoxText"] as RichTextBox;
            if (found == null) return;

            found.TextChanged -= CodeTextBox_TextChanged;
            found.TextChanged += CodeTextBox_TextChanged;

            codeTextBox = found;
        }


        private void HighlightLines(int startLine, int endLine)
        {
            if (startLine < 0 || endLine < 0) return;

            int savedStart = codeTextBox.SelectionStart;
            int savedLen = codeTextBox.SelectionLength;

            SendMessage(codeTextBox.Handle, WM_SETREDRAW, false, 0);

            for (int line = startLine; line <= endLine; line++)
            {
                int start = codeTextBox.GetFirstCharIndexFromLine(line);
                if (start < 0) continue;

                int next = codeTextBox.GetFirstCharIndexFromLine(line + 1);
                int length = (next < 0 ? codeTextBox.TextLength : next) - start;

                if (length <= 0) continue;

                string lineText = codeTextBox.Text.Substring(start, length);

                // сброс цвета
                codeTextBox.Select(start, length);
                codeTextBox.SelectionColor = keys.baseColor;

                int i = 0;
                while (i < lineText.Length)
                {
                    if (!char.IsLetter(lineText[i])) { i++; continue; }

                    int wordStart = i;
                    while (i < lineText.Length && char.IsLetter(lineText[i]))
                        i++;

                    int wordLength = i - wordStart;
                    string word = lineText.Substring(wordStart, wordLength);

                    Color color = keys.GetColorByKeyWord(word);
                    if (color != keys.baseColor)
                    {
                        codeTextBox.Select(start + wordStart, wordLength);
                        codeTextBox.SelectionColor = color;
                    }
                }
            }

            codeTextBox.Select(savedStart, savedLen);

            SendMessage(codeTextBox.Handle, WM_SETREDRAW, true, 0);
            codeTextBox.Refresh();
        }


        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (codeTextBox == null) return;

            string newText = codeTextBox.Text;

            int startDiff = 0;
            while (startDiff < previousText.Length &&
                   startDiff < newText.Length &&
                   previousText[startDiff] == newText[startDiff])
                startDiff++;

            int endOld = previousText.Length - 1;
            int endNew = newText.Length - 1;

            while (endOld >= startDiff && endNew >= startDiff &&
                   previousText[endOld] == newText[endNew])
            {
                endOld--;
                endNew--;
            }

            // номера строк
            int startLine = codeTextBox.GetLineFromCharIndex(startDiff);
            int endLine = codeTextBox.GetLineFromCharIndex(endNew);

            HighlightLines(startLine, endLine);

            previousText = newText;
        }


        public void HighlightExceptions()
        {

        }

    }
}
