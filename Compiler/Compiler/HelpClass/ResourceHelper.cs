using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    public static class ResourceHelper
    {
        public static string TempFolder =>
            Path.Combine(Path.GetTempPath(), "My_compiler");
        public static void ExtractResources()
        {
            Directory.CreateDirectory(TempFolder);

            ExtractFile("CompilerGUI.HTML.Task.html", "Task.html");
            ExtractFile("CompilerGUI.HTML.Grammar.html", "Grammar.html");
            ExtractFile("CompilerGUI.HTML.Classification.html", "Classification.html");
            ExtractFile("CompilerGUI.HTML.Method.html", "Method.html");
            ExtractFile("CompilerGUI.HTML.References.html", "References.html");
            ExtractFile("CompilerGUI.HTML.Tests.html", "Tests.html");

            ExtractFile("CompilerGUI.HTML.styles.css", "styles.css");
        }

        private static void ExtractFile(string resourceName, string outputFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new Exception($"Ресурс не найден: {resourceName}");

            string outputPath = Path.Combine(TempFolder, outputFileName);

            using FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            stream.CopyTo(file);
        }

        public static string GetTempFilePath(string fileName)
        {
            return Path.Combine(TempFolder, fileName);
        }

        public static void OpenHtml(string fileName)
        {
            string path = GetTempFilePath(fileName);

            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден: " + path);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
    }
}
