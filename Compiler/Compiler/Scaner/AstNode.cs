using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public abstract class AstNode
    {
        public abstract void Print(string indent, bool isLast);
    }

    public class ProgramNode : AstNode
    {
        public List<AstNode> Nodes = new();
        public override void Print(string indent, bool isLast)
        {
            Console.WriteLine("Program");
            for (int i = 0; i < Nodes.Count; i++)
                Nodes[i].Print(indent, i == Nodes.Count - 1);
        }
    }

    public class ListInitNode : AstNode
    {
        public string Id;
        public List<AstNode> Elements = new();
        public override void Print(string indent, bool isLast)
        {
            string marker = isLast ? "└── " : "├── ";
            Console.WriteLine(indent + marker + $"Assignment (id: {Id})");
            string childIndent = indent + (isLast ? "    " : "│   ");
            for (int i = 0; i < Elements.Count; i++)
                Elements[i].Print(childIndent, i == Elements.Count - 1);
        }
    }

    public class LiteralNode : AstNode
    {
        public string Type;
        public string Value;
        public override void Print(string indent, bool isLast)
        {
            string marker = isLast ? "└── " : "├── ";
            Console.WriteLine(indent + marker + $"Literal ({Type}: {Value})");
        }
    }
}
