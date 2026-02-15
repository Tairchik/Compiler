using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class ControllerTextHighlighting
    {
        private string formatCode = "";
        private KeyWordViewList keys;
        public RichTextBox codeTextBox;
        private Dictionary<string, Dictionary<Color, string[]>> dict = new Dictionary<string, Dictionary<Color, string[]>>()
        {
            ["txt"] = new Dictionary<Color, string[]> {
                [Color.Blue] = ["int", "float", "double"],
                [Color.Black] = ["@BASE@"],
            },
            ["base"] = new Dictionary<Color, string[]> { [Color.Black] = ["@BASE@"] }
        };

        public ControllerTextHighlighting(string formatCode)
        {
            this.formatCode = formatCode;
            var result = new Dictionary<Color, string[]>();
            if (dict.TryGetValue(formatCode, out result))
            {
                keys = new KeyWordViewList(dict[formatCode]);
            }
            else
            {
                formatCode = "base";
                keys = new KeyWordViewList(dict[formatCode]);
            }
        }

        public void InitTextBox(TabPage tabPape)
        {
            try
            {
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)tabPape.Controls.Find("tableLayoutPanel", true)[0];
                codeTextBox = (RichTextBox)tableLayoutPanel.Controls["richTextBoxText"];

                HighlightCode();
            }
            catch (Exception ex)
            {

            }
        }

        public void HighlightCode()
        {
            if (codeTextBox == null || string.IsNullOrEmpty(codeTextBox.Text))
                return;

            int savedSelectionStart = codeTextBox.SelectionStart;
            int savedSelectionLength = codeTextBox.SelectionLength;

            codeTextBox.SelectAll();
            codeTextBox.SelectionColor = keys.baseColor;

            string text = codeTextBox.Text;
            int i = 0;
            while (i < text.Length)
            {
                if (!char.IsLetter(text[i]))
                {
                    i++;
                    continue;
                }

                int start = i;
                while (i < text.Length && char.IsLetter(text[i]))
                {
                    i++;
                }
                int length = i - start;
                string word = text.Substring(start, length);

                Color wordColor = keys.GetColorByKeyWord(word);

                if (wordColor != keys.baseColor)
                {
                    codeTextBox.Select(start, length);
                    codeTextBox.SelectionColor = wordColor;
                }
            }
            codeTextBox.Select(savedSelectionStart, savedSelectionLength);
        }
        public void HighlightExceptions()
        {

        }

    }
}
