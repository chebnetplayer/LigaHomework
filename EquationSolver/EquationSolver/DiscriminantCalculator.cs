using System;

namespace EquationSolver
{
    public class DiscriminantCalculator
    {
        public static int GetDiscriminant(int[] parameters)
        {
            int discriminant = parameters[1] * parameters[1] - 4 * parameters[0] * parameters[2];
            return discriminant;
        }
    }
}
