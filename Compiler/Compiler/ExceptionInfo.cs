using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CompilerGUI
{
    public class ExceptionInfo
    {
        public int Number { get; set; }
        public string FilePath { get; set; }
        public int Line { get; set; }
        public string ExceptionMessage { get; set; }

        [Browsable(false)]
        public string FileName { get; set; }

    }
}
