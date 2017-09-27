using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EqualSolverUnitTest
{
    [TestClass]
    public class ValidationStringUnitTest
    {
        [TestMethod]
         public void String_IsItNormalEqual()
        {
            var text = "+-1*x^2+-2*x+-10=0";
            bool expected = EquationSolver.ValidationString.ValidateString(text);
            Assert.AreEqual(true, expected);

        }
        [TestMethod]
        public void Equal_IsNullinEqual()
        {
            var equal = "0*x^2+1*x+-10=0";
            bool expected = EquationSolver.ValidationString.FindNull(equal);
            Assert.AreEqual(false, expected);
        } 
    }
    [TestClass]
    public class ParsingEquationUnitTest
    {
        [TestMethod]
        public void equalString_IsitParameters()
        {
            var expected = "+-1*x^2 + -2*x + -10 = 0";
            int[] trueParameters = { -1, -2, -10 };
            var parameters = EquationSolver.ParsingEquation.GetParameters(expected);
            CollectionAssert.AreEqual(trueParameters, parameters);
        }
        [TestMethod]
        public void string_IsItInt()
        {
            var expected = "+-1*x^2+-2*x+-10";
            var trueParameter = -10;
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
    [TestClass]
    public class DiscriminantCalculationUnitTest
    {
        [TestMethod]
        public void Parameters_ItShouldbeDiscriminant()
        {
            int[] expected = { 2, -8, 6 };
            var actual = EquationSolver.DiscriminantCalculation.GetDiscriminant(expected);
            Assert.AreEqual(16, actual);
        }
    }
    [TestClass]
    public class CheckDiscriminantUnitTest
    {
        [TestMethod]
        public void Discriminant_IsitWithoutMinus()
        {
            var expected = 0;
            bool actual = EquationSolver.DiscriminantChecker.DiscriminantCheck(expected);
            Assert.AreEqual(true, actual);
        }
    }
    [TestClass]
    public class RootsFinderUnitTest
    {
        [TestMethod]
        public void ParametersandDiscriminant_X1()
        {
            int[] parameters = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculation.GetDiscriminant(parameters);
            double actual = EquationSolver.RootsFinder.GetX1(parameters, discriminant);
            Assert.AreEqual(3, actual);
        }
        [TestMethod]
        public void ParametresandDiscriminant_X2()
        {
            int[] parameters = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculation.GetDiscriminant(parameters);
            double actual = EquationSolver.RootsFinder.GetX2(parameters, discriminant);
            Assert.AreEqual(1, actual);
        }
    }
        

    

}
