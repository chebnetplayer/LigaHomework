using System;
using System.Text.RegularExpressions;

namespace EquationSolver
{
    public class ValidatorString
    {
        public static bool IsValidEquation(string equal)
        {
          var pattern = @"^(\+)?(-)?[1-9](\d+)?\*x\^2\+(-)?[1-9](\d+)?\*x\+(-)?[1-9](\d+)?=0$";
          return Regex.IsMatch(equal, pattern,RegexOptions.IgnoreCase);
        }
    }
    public class ParsingEquation
    {
       public static int[] GetParameters(string equation)
        {
            int[] parameters = new int[3];
            equation= DeleteSymbolsInLast(equation, '=');
            parameters[2] = GetParameter(equation);
            equation= DeleteSymbolsInLast(equation, '*');
            parameters[1] = GetParameter(equation);
            equation= DeleteSymbolsInLast(equation, '*');
            parameters[0] = GetParameter(equation);
            return parameters;
        }
        public static string DeleteSymbolsInLast(string text,char symbol)
        {
            int indexOfsymbol = text.LastIndexOf(symbol);
            return text.Remove(indexOfsymbol);
        }
        public static int GetParameter(string text)
        {
            int lastoperator = text.LastIndexOf("+");
            if (lastoperator != -1)
                return int.Parse(text.Remove(0, lastoperator+1));
            else return int.Parse(text);
        }
    }
    public class DiscriminantCalculator
    {
        public static int GetDiscriminant(int[] parameters)
        {
            int discriminant = parameters[1]*parameters[1] - 4 * parameters[0] * parameters[2];
            return discriminant;
        }
    }
    public class DiscriminantValidChecker
    {
        public static bool DiscriminantCheck(int discriminant)
        {
            if (discriminant >= 0) return true;
            else return false;
        }
    }
    public class RootsFinder
    {
        public static double GetX1(int[] parameters, int discriminant)
        {
            double x1 = (-parameters[1] + Math.Sqrt(discriminant)) /( 2 * parameters[0]);
            return x1;
        }
        public static double GetX2(int[] parameters, int discriminant)
        {
            double x2 = (-parameters[1] - Math.Sqrt(discriminant)) / (2 * parameters[0]);
            return x2;
        }
    }

}
