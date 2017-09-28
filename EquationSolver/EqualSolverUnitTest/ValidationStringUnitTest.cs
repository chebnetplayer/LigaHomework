using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTests
{
    [TestClass]
    public class ValidationStringUnitTest
    {
        [TestMethod]
        public void ValidEquationString_ItShouldbeNormalEquation()
        {
            var equation = "+-1*x^2+-2*x+10=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equation);
            Assert.AreEqual(true, expected);
        }
        [TestMethod]
        public void NotValidEquationString1_ItshouldbeUnNormalEquation()
        {
            var equation = "fcwerfdgb";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equation);
            Assert.AreEqual(false, expected);

        }
        [TestMethod]
        public void NotValidEquationString2_ItshouldbeUnNormalEquation()
        {
            var equation = "+-1x2+2x+10=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equation);
            Assert.AreEqual(false, expected);
        }
        [TestMethod]
        public void NotValidEquationString3_ItshouldbeUnNormalEquation()
        {
            var equation = "-1*x^2+2*x+10";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equation);
            Assert.AreEqual(false, expected);
        }
        [TestMethod]
        public void EquationStringWhenFirstParameterIsnull_IsNullinEqual()
        {
            var equation = "0*x^2+1*x+-10=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equation);
            Assert.AreEqual(false, expected);
        }
        [TestMethod]
        public void EquationStringWhenSecondParameterIsnull_IsNullinEqual()
        {
            var equal = "1*x^2+0*x+-10=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equal);
            Assert.AreEqual(false, expected);
        }
        public void EquationStringWhenThirdParameterIsnull_IsNullinEqual()
        {
            var equal = "2*x^2+1*x+-0=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equal);
            Assert.AreEqual(false, expected);
        }
    }
}
