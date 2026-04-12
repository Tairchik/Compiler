using CompilerGUI.HelpClass;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CompilerGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ResourceHelper.ExtractResources();

            ApplicationConfiguration.Initialize();
            Application.Run(new CompilerForm());
        }
    }
}