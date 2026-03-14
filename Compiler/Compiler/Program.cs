using System.Reflection;
using System.Runtime.InteropServices;

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


            if (!File.Exists(targetPath))
            {
                try
                {
                    string resourceName = "CompilerGUI." + dllName;
                    using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        if (stream != null)
                        {
                            using (FileStream fs = new FileStream(targetPath, FileMode.Create))
                            {
                                stream.CopyTo(fs);
                            }
                        }
                    }
                }
                catch { }
            }
            SetDllDirectory(targetPath.Replace(dllName, ""));

            ApplicationConfiguration.Initialize();
            Application.Run(new CompilerForm());
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);
    }
}