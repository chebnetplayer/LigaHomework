using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTest
{

    [TestClass]
    public class CheckValidDiscriminantUnitTest
    {
        [TestMethod]
        public void Discriminant_IsDiscriminantWithoutMinus()
        {
            var expected = 0;
            bool actual = EquationSolver.DiscriminantValidChecker.DiscriminantCheck(expected);
            Assert.AreEqual(true, actual);
        }
    }
}
