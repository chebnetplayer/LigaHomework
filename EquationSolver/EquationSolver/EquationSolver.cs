using System;
using System.Text.RegularExpressions;

namespace EquationSolver
{
    public class ValidationString
    {
        public static bool ValidateString(string equal)
        {//+-1*x^2+-2*x+-10=0
          var pattern = @"^(\+-[0-9]{1,}|[0-9]{1,})\*x\^2" + @"(\+-[0-9]{0,10}|[0-9]{0,10})\*x" + @"(\+-[0-9]{0,10}|[0-9]{0,10})=0";
          return Regex.IsMatch(equal, pattern,RegexOptions.IgnoreCase);
        }
        public static bool FindNull(string equal)
        {
            var pattern = @"^(0|(\+0|-0))";
            return Regex.IsMatch(equal, pattern);
        }
        public static bool CheckNormalEqual(bool first, bool two)
        {
            return first && two;
        }
    }
    public class ParsingEquation
    {
       public static int[] GetParameters(string equal)
        {
            int[] parameters = new int[3];
            equal= DeleteSymbolsInLast(equal, '=');
            parameters[2] = GetParameter(equal);
            equal= DeleteSymbolsInLast(equal, '*');
            parameters[1] = GetParameter(equal);
            equal= DeleteSymbolsInLast(equal, '*');
            parameters[0] = GetParameter(equal);
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
    public class DiscriminantCalculation
    {
        public static int GetDiscriminant(int[] parameters)
        {
            int discriminant = parameters[1]*parameters[1] - 4 * parameters[0] * parameters[2];
            return discriminant;
        }
    }
    public class DiscriminantChecker
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
