using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    internal class RegexProcessor
    {
        private readonly Dictionary<int, string> _patterns = new Dictionary<int, string>
        {
            { 0, @"[А-Яа-яЁё0-9!@#$%^&*()_\-+=\[{\]};:'"",.<>/?\\|`~]+" }, // password
            { 1, @"@[A-Za-z0-9]{3,19}" }, // username
            { 2, @" (?!BG|GB|NK|KN|TN|NT|ZZ)[ABCEGHJ-PR-TW-Z][ABCEGHJ-NPR-TW-Z]\d{6}[A-D]?" } // NIN
        };

        public List<RegexMatchResult> Process(string text, int patternNumber)
        {
            if (!_patterns.ContainsKey(patternNumber))
                throw new ArgumentException("Неверный номер регулярного выражения");

            var regex = new Regex(_patterns[patternNumber]);
            var results = new List<RegexMatchResult>();

            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            int absoluteIndex = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                foreach (Match match in regex.Matches(line))
                {
                    results.Add(new RegexMatchResult
                    {
                        FoundText = match.Value,
                        Line = i + 1,
                        PositionStart = match.Index + 1,
                        PositionEnd = match.Index + match.Length,
                        Length = match.Length,
                        AbsoluteIndex = absoluteIndex + match.Index
                    });
                }

                absoluteIndex += line.Length + 1;
            }

            return results;
        }
    }
}
