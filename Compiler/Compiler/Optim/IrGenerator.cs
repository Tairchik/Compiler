using CompilerGUI.Scaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Optim
{
    public class IrGenerator
    {
        private int _tempCounter = 1;

        public List<IrInstruction> Generate(ProgramNode root)
        {
            var instructions = new List<IrInstruction>();

            foreach (var node in root.Nodes)
            {
                if (node is ListInitNode listNode)
                {
                    instructions.Add(new IrInstruction("ALLOC_LIST", "", "", listNode.Id));

                    foreach (var element in listNode.Elements)
                    {
                        if (element is LiteralNode lit)
                        {
                            string tempVar = $"t{_tempCounter++}";
                            instructions.Add(new IrInstruction("ASSIGN", lit.Value, "", tempVar));
                            instructions.Add(new IrInstruction("APPEND", listNode.Id, tempVar, ""));
                        }
                    }
                }
            }
            return instructions;
        }
    }
}
