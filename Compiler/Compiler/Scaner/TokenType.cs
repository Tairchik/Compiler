using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public enum TokenType
    {
        // ИНДЕТИФИКАТОРЫ
        Id = 10, 
        // КОНСТАНТЫ
        ConstInt = 20, 
        ConstFloat = 21,
        ConstString = 22,
        ConstTrue = 23,
        ConstFalse = 24,
        // РАЗДЕЛИТЕЛИ
        WhiteSpace = 30, 
        Comma = 31,
        OpenListDelimiter = 32,
        CloseListDelimiter = 33,
        End_operator = 34,
        // МАТЕМАТИЧЕСКИЕ ЗНАКИ
        Equal = 40, 
        Plus = 41,
        Minus = 42,
        // ОШИБКИ
        Error = 99
    }
}
