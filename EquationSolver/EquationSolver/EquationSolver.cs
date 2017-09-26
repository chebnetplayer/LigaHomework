using System;
using System.Text.RegularExpressions;

namespace EquationSolver
{
    public class ValidationString
    {
        public static bool ValidateString(string equal)
        {//+-1*x^2+-2*x+-10=0
          var pattern = @"^(\+-[0-9]{0,10}|[0-9]{0,10})\*x\^2" + @"(\+-[0-9]{0,10}|[0-9]{0,10})\*x" + @"(\+-[0-9]{0,10}|[0-9]{0,10})=0";
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
       public static int[] GetParametres(string equal)
        {
            int[] parametres = new int[3];
            equal= DeleteSymbolsInLast(equal, '=');
            parametres[2] = GetParametr(equal);
            equal= DeleteSymbolsInLast(equal, '*');
            parametres[1] = GetParametr(equal);
            equal= DeleteSymbolsInLast(equal, '*');
            parametres[0] = GetParametr(equal);
            return parametres;
        }
        public static string DeleteSymbolsInLast(string text,char symbol)
        {
            int indexOfsymbol = text.LastIndexOf(symbol);
            return text.Remove(indexOfsymbol);
        }
        public static int GetParametr(string text)
        {
            int lastoperator = text.LastIndexOf("+");
            if (lastoperator != -1)
                return int.Parse(text.Remove(0, lastoperator+1));
            else return int.Parse(text);
        }
    }
    public class DiscriminantCalculation
    {
        public static int GetDiscriminant(int[] parametres)
        {
            int discriminant = parametres[1]*parametres[1] - 4 * parametres[0] * parametres[2];
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
        public static double GetX1(int[] parametres, int discriminant)
        {
            double x1 = (-parametres[1] + Math.Sqrt(discriminant)) /( 2 * parametres[0]);
            return x1;
        }
        public static double GetX2(int[] parametres, int discriminant)
        {
            double x2 = (-parametres[1] - Math.Sqrt(discriminant)) / (2 * parametres[0]);
            return x2;
        }
    }

}
