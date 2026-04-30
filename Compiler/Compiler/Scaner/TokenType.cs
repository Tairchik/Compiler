using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.Scaner
{
    public enum TokenType
    {
        // Идентификатор и константы
        Id = 10,
        ConstInt = 20,

        // Разделители
        WhiteSpace = 30,
        OpenParen = 31,  // (
        CloseParen = 32, // )
        Semicolon = 33,  // ;

        // Математические знаки
        Plus = 40,       // +
        Minus = 41,      // -
        Multiply = 42,   // *
        Divide = 43,     // /
        Mod = 44,        // %
        IntDivide = 45,  // //
        Power = 46,      // ** 

        // Ошибки
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
                    return "Целочисленная константа";
                case TokenType.WhiteSpace:
                    return "Разделитель (пробел)";
                case TokenType.OpenParen:
                    return "Открывающая скобка";
                case TokenType.CloseParen:
                    return "Закрывающая скобка";
                case TokenType.Semicolon:
                    return "Точка с запятой";
                case TokenType.Plus:
                    return "Оператор сложения (+)";
                case TokenType.Minus:
                    return "Оператор вычитания (-)";
                case TokenType.Multiply:
                    return "Оператор умножения (*)";
                case TokenType.Divide:
                    return "Оператор деления (/)";
                case TokenType.IntDivide:
                    return "Оператор деления нацело (//)";
                case TokenType.Mod:
                    return "Оператор остатка от деления (%)";
                case TokenType.Error:
                    return "Лексическая ошибка";
                default:
                    return "Неизвестная лексема";
            }
        }
    }
}

