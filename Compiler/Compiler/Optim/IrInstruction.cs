using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Optim
{
    public class IrInstruction
    {
        public string Op { get; set; }
        public string Arg1 { get; set; }
        public string Arg2 { get; set; }
        public string Result { get; set; }

        public IrInstruction(string op, string arg1, string arg2, string result)
        {
            Op = op;
            Arg1 = arg1;
            Arg2 = arg2;
            Result = result;
        }

        public override string ToString()
        {
            if (Op == "ASSIGN") return $"{Result} = {Arg1}";
            if (Op == "ALLOC_LIST") return $"{Result} = []";
            if (Op == "APPEND") return $"APPEND {Arg1}, {Arg2}";
            return $"{Result} = {Arg1} {Op} {Arg2}";
        }
    }
}
