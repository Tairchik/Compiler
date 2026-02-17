using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI
{
    public class LanguageItem
    {
        public string Code { get; }
        public string DisplayName { get; }

        public LanguageItem(string code)
        {
            Code = code;

            try
            {
                var culture = new System.Globalization.CultureInfo(code);
                DisplayName = culture.NativeName;
            }
            catch
            {
                DisplayName = code;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }

}
