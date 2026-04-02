using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    public class RegexMatchResult
    {
        public string FoundText { get; set; }

        public int Length { get; set; }
        public string Positon => $"Строка: {Line}, Позиция: {PositionStart} - {PositionEnd}";

        [Browsable(false)]
        public int AbsoluteIndex { get; set; }
        [Browsable(false)]
        public int PositionStart { get; set; }
        [Browsable(false)]
        public int PositionEnd { get; set; }
        [Browsable(false)]
        public int Line { get; set; }
    }
}
