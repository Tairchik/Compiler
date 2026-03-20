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

                string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CompilerGUI");
                if (!Directory.Exists(appDataPath)) Directory.CreateDirectory(appDataPath);

                string dllName = "NativeParser.dll";
                string targetPath = Path.Combine(appDataPath, dllName);

                string resourceName = "CompilerGUI." + dllName;

                ExtractResourceIfChanged(resourceName, targetPath);

                try
                {
                    if (File.Exists(targetPath))
                    {
                        NativeLibrary.Load(targetPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Критическая ошибка: не удалось загрузить ядро парсера.\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               SetDllDirectory(appDataPath);
            

            ApplicationConfiguration.Initialize();
            Application.Run(new CompilerForm());
        }

        private static void ExtractResourceIfChanged(string resourceName, string targetPath)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null) return;

                bool needUpdate = true;

                if (File.Exists(targetPath))
                {
                    FileInfo existingFile = new FileInfo(targetPath);
                    if (existingFile.Length == stream.Length)
                    {
                        needUpdate = false;
                    }
                }

                if (needUpdate)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fs);
                        }
                    }
                    catch (IOException)
                    {

                    }
                }
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);
    }
}