using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public enum TokenType
    {
        // ИНДЕТИФИКАТОРЫ
        Id = 10, 
        // КОНСТАНТЫ
        ConstInt = 20, 
        ConstFloat = 21,
        ConstString = 22,
        ConstTrue = 23,
        ConstFalse = 24,
        // РАЗДЕЛИТЕЛИ
        WhiteSpace = 30, 
        Comma = 31,
        OpenListDelimiter = 32,
        CloseListDelimiter = 33,
        End_operator = 34,
        // МАТЕМАТИЧЕСКИЕ ЗНАКИ
        Equal = 40, 
        Plus = 41,
        Minus = 42,
        // ОШИБКИ
        Error = 99
    }

    public static class TokenToString 
    {
        public static string GetString(TokenType token) 
        { 
            switch (token)
            {
                case TokenType.Id:
                    return "Идентификатор";
                case TokenType.ConstInt:
                    return "Целочисленная константа без знака";
                case TokenType.ConstString:
                    return "Строковая константа";
                case TokenType.ConstFloat:
                    return "Вещественная константа без знака";
                case TokenType.ConstTrue:
                    return "Логическая константа (True)";
                case TokenType.ConstFalse:
                    return "Логическая константа (False)";
                case TokenType.WhiteSpace:
                    return "Разделитель (пробел)";
                case TokenType.Comma:
                    return "Разделитель (запятая)";
                case TokenType.OpenListDelimiter:
                    return "Разделитель (открывающая скобка)";
                case TokenType.CloseListDelimiter:
                    return "Разделитель (закрывающая скобка)";
                case TokenType.End_operator:
                    return "Конец оператора";
                case TokenType.Equal:
                    return "Оператор присваивания";
                case TokenType.Minus:
                    return "Арифметический оператор (-)";
                case TokenType.Plus:
                    return "Арифметический оператор (+)";
                case TokenType.Error:
                    return "Лексическая ошибка";
                default: 
                    return "Неизвестная лексема";
            }
        }
    }
}

