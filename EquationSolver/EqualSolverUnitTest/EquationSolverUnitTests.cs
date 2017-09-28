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
            Assert.AreEqual(true, expected);
        }
        [TestMethod]
        public void EquationStringWhenSecondParameterIsnull_IsNullinEqual()
        {
            var equal = "1*x^2+0*x+-10=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equal);
            Assert.AreEqual(true, expected);
        }
        public void EquationStringWhenThirdParameterIsnull_IsNullinEqual()
        {
            var equal = "2*x^2+1*x+-0=0";
            bool expected = EquationSolver.ValidatorString.IsValidEquation(equal);
            Assert.AreEqual(true, expected);
        }
    }
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
    [TestClass]
    public class CheckDiscriminantUnitTest
    {
        [TestMethod]
        public void Discriminant_IsDiscriminantWithoutMinus()
        {
            var expected = 0;
            bool actual = EquationSolver.DiscriminantValidChecker.DiscriminantCheck(expected);
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
