using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CompilerGUI.HelpClass
{
    public class ExceptionInfo
    {
        public int Number { get; set; }
        public string FilePath { get; set; }
        public string Location { get; set; }
        public string ExceptionMessage { get; set; }

        [Browsable(false)]
        public string FileName { get; set; }
        [Browsable(false)]
        public int Column { get; set; }
        [Browsable(false)]
        public int StartPos { get; set; }
        [Browsable(false)]
        public int EndPos { get; set; }
    }
}
