using System;

namespace EquationSolver
{
    public class RootsFinder
    {
        public static double GetX1(int[] parameters, int discriminant)
        {
            double x1 = (-parameters[1] + Math.Sqrt(discriminant)) / (2 * parameters[0]);
            return x1;
        }
        public static double GetX2(int[] parameters, int discriminant)
        {
            double x2 = (-parameters[1] - Math.Sqrt(discriminant)) / (2 * parameters[0]);
            return x2;
        }
    }
}
