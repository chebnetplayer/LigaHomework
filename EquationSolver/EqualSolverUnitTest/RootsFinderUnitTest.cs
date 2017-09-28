using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTest
{
    [TestClass]
    public class RootsFinderUnitTest
    {
        [TestMethod]
        public void ParametersandDiscriminant_X1()
        {
            int[] parameters = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculator.GetDiscriminant(parameters);
            double actual = EquationSolver.RootsFinder.GetX1(parameters, discriminant);
            Assert.AreEqual(3, actual);
        }
        [TestMethod]
        public void ParametresandDiscriminant_X2()
        {
            int[] parameters = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculator.GetDiscriminant(parameters);
            double actual = EquationSolver.RootsFinder.GetX2(parameters, discriminant);
            Assert.AreEqual(1, actual);
        }
    }
}
