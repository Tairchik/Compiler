namespace CompilerGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new CompilerForm());
            // Можно сделать json файл с настройками и языком
        }
    }
}