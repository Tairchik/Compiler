using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public class Token
    {
        public int Code => (int)Type;
        public string Value { get; set; } = string.Empty;
        [Browsable(false)]
        public int Line { get; set; }
        [Browsable(false)]
        public int StartPos { get; set; }
        [Browsable(false)]
        public int EndPos { get; set; }
        [Browsable(false)]
        public int AbsoluteIndex { get; set; }
        [Browsable(false)]
        public TokenType Type { get; set; }
        public string TypeName => TokenToString.GetString(Type);
        public string Location => $"Стр: {Line}, Поз: {StartPos}-{EndPos}";
    }
}
