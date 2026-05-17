using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Optim
{
    public class Optimizer
    {
        public List<IrInstruction> OptimizeConstants(List<IrInstruction> inputIr)
        {
            var optimized = new List<IrInstruction>();
            foreach (var inst in inputIr)
            {
                if (inst.Op == "ASSIGN" && inst.Arg1.StartsWith("+"))
                {
                    optimized.Add(new IrInstruction("ASSIGN", inst.Arg1.Substring(1), "", inst.Result));
                }
                else
                {
                    optimized.Add(inst);
                }
            }
            return optimized;
        }

        public List<IrInstruction> RemoveDuplicates(List<IrInstruction> inputIr)
        {
            var optimized = new List<IrInstruction>();
            var seenValues = new HashSet<string>();
            var tempToValueMap = new Dictionary<string, string>();

            foreach (var inst in inputIr)
            {
                if (inst.Op == "ASSIGN")
                {
                    tempToValueMap[inst.Result] = inst.Arg1;
                    optimized.Add(inst);
                }
                else if (inst.Op == "APPEND")
                {
                    string tempVar = inst.Arg2;
                    if (tempToValueMap.TryGetValue(tempVar, out string val))
                    {
                        if (!seenValues.Contains(val))
                        {
                            seenValues.Add(val);
                            optimized.Add(inst);
                        }
                    }
                }
                else
                {
                    optimized.Add(inst);
                }
            }

            return CleanUpDeadAssignments(optimized);
        }

        private List<IrInstruction> CleanUpDeadAssignments(List<IrInstruction> inputIr)
        {
            var usedTemps = inputIr.Where(i => i.Op == "APPEND").Select(i => i.Arg2).ToHashSet();
            return inputIr.Where(i => i.Op != "ASSIGN" || usedTemps.Contains(i.Result)).ToList();
        }
    }
}
