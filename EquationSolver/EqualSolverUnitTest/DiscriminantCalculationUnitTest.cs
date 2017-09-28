using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTest
{
    [TestClass]
    public class DiscriminantCalculationUnitTest
    {
        [TestMethod]
        public void Parameters_ItShouldbeDiscriminant()
        {
            int[] expected = { 2, -8, 6 };
            var actual = EquationSolver.DiscriminantCalculator.GetDiscriminant(expected);
            Assert.AreEqual(16, actual);
        }
    }
}
