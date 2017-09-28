using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTest
{
    [TestClass]
    public class ParsingEquationUnitTest
    {
        [TestMethod]
        public void equalString_AreitTrueParameters()
        {
            var expected = "+-1*x^2 + -2*x + -10 = 0";
            int[] trueParameters = { -1, -2, -10 };
            var parameters = EquationSolver.ParsingEquation.GetParameters(expected);
            CollectionAssert.AreEqual(trueParameters, parameters);
        }
        [TestMethod]
        public void stringEquation_IsItIntLastParameter()
        {
            var expected = "+-1*x^2+-2*x+-10";
            var trueParameter = -10;
            var parameter = EquationSolver.ParsingEquation.GetParameter(expected);
            Assert.AreEqual(trueParameter, parameter);
        }
        [TestMethod]
        public void string_IsItIntParameter()
        {
            var expected = "+-1";
            var trueParameter = -1;
            var parameter = EquationSolver.ParsingEquation.GetParameter(expected);
            Assert.AreEqual(trueParameter, parameter);
        }
        [TestMethod]
        public void string_IsItCorrectsymbolsremove()
        {
            var expected = "1*x^2+";
            var trueString = "1";
            var actual = EquationSolver.ParsingEquation.DeleteSymbolsInLast(expected, '*');
            Assert.AreEqual(trueString, actual);
        }
    }
}
