using System;

namespace EquationSolver
{
    public class ParsingEquation
    {
        public static int[] GetParameters(string equation)
        {
            int[] parameters = new int[3];
            equation = DeleteSymbolsInLast(equation, '=');
            parameters[2] = GetParameter(equation);
            equation = DeleteSymbolsInLast(equation, '*');
            parameters[1] = GetParameter(equation);
            equation = DeleteSymbolsInLast(equation, '*');
            parameters[0] = GetParameter(equation);
            return parameters;
        }
        public static string DeleteSymbolsInLast(string text, char symbol)
        {
            int indexOfsymbol = text.LastIndexOf(symbol);
            return text.Remove(indexOfsymbol);
        }
        public static int GetParameter(string text)
        {
            int lastoperator = text.LastIndexOf("+");
            if (lastoperator != -1)
                return int.Parse(text.Remove(0, lastoperator + 1));
            else return int.Parse(text);
        }
    }
}
