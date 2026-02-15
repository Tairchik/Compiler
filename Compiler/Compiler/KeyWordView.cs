using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class KeyWordView
    {
        public Color Color;
        public List<string> KeyWords;
        public KeyWordView(Color color, List<string> keyWords) 
        {
            KeyWords = keyWords;
            Color = color;
        }
        public KeyWordView(Color color)
        {
            KeyWords = new List<string>();
            Color = color;
        }
    }
}
