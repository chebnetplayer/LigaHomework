using System;

namespace EquationSolver
{
    public class DiscriminantValidChecker
    {
        public static bool DiscriminantCheck(int discriminant)
        {
            if (discriminant >= 0) return true;
            else return false;
        }
    }
}
