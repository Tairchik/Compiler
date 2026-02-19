using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class FileClass
    {
        public string FileName {  get; set; }
        public string FilePath { get; set; }
        public string Ext { get => "txt"; }
        public bool IsSaved { get; set; }
        public FileClass(string fileName, string filePath, bool isSaved) 
        {
            FileName = fileName;
            FilePath = filePath;
            IsSaved = isSaved;
        }
    }
}
