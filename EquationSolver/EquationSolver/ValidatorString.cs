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
}
