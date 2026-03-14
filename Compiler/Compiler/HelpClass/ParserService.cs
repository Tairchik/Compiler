using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    public class ParserService
    {
        // Изменяем делегат: принимаем int и строку
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void ErrorCallbackDelegate(int line, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

        // Импорт функции (используем UTF8 для безопасности)
        [DllImport("NativeParser.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int ParseSourceCode(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string sourceCode,
            ErrorCallbackDelegate errorCb);

        public (bool IsSuccess, string Message, List<int>? line) Parse(string sourceCode)
        {
            var errorBuilder = new StringBuilder();
            List<int> lines = new List<int>();

            ErrorCallbackDelegate callback = (line, msg) =>
            {
                errorBuilder.AppendLine(msg);
                lines.Add(line);
            };

            int result = ParseSourceCode(sourceCode, callback);
            string errors = errorBuilder.ToString().Trim();

            if (result == 0 && string.IsNullOrEmpty(errors))
            {
                return (true, LocalizationService.Get("Success"), null);
            }
            else
            {
                return (false, errors, lines);
            }
        }
    }
}
