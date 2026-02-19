using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    public class KeyWordFashion
    {
        public Color Color;
        public List<string> KeyWords;
        public KeyWordFashion(Color color, List<string> keyWords) 
        {
            KeyWords = keyWords;
            Color = color;
        }
        public KeyWordFashion(Color color)
        {
            KeyWords = new List<string>();
            Color = color;
        }
    }
}
