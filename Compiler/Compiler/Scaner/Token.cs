using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public class Token
    {
        public int Code
        {
            get 
            {
                return (int) Type;
            }
        }
        public string Value { get; set; }
        [Browsable(false)]
        public int Line { get; set; }
        [Browsable(false)]
        public int StartPos { get; set; }
        [Browsable(false)]
        public int EndPos { get; set; }
        [Browsable(false)]
        public int AbsoluteIndex { get; set; }
        [Browsable(false)]
        public TokenType Type { get; set; }
        public string TypeName => Type switch
        {
            TokenType.Id => "Идентификатор",
            TokenType.ConstInt => "Целочисленная константа без знака",
            TokenType.ConstString => "Строковая константа",
            TokenType.ConstFloat => "Вещественная константа без знака",
            TokenType.ConstTrue => "Логическая константа (True)",
            TokenType.ConstFalse => "Логическая константа (False)",
            TokenType.WhiteSpace => "Разделитель (пробел)",
            TokenType.Comma => "Разделитель (запятая)",
            TokenType.OpenListDelimiter => "Разделитель (закрывающая скобка)",
            TokenType.CloseListDelimiter => "Разделитель (открывающая скобка)",
            TokenType.End_operator => "Конец оператора",
            TokenType.Equal => "Оператор присваивания",
            TokenType.Minus => "Арифметический оператор (-)",
            TokenType.Plus => "Арифметический оператор (+)",
            TokenType.Error => "Лексическая ошибка",
            _ => "Неизвестная лексема"
        };

        public string Location => $"Стр: {Line}, Поз: {StartPos}-{EndPos}";
    }
}
