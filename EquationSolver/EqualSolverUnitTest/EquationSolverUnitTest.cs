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
        public void equalString_IsitParametres()
        {
            var expected = "+-1*x^2 + -2*x + -10 = 0";
            int[] trueParametres = { -1, -2, -10 };
            var parametres = EquationSolver.ParsingEquation.GetParametres(expected);
            CollectionAssert.AreEqual(trueParametres, parametres);
        }
        [TestMethod]
        public void string_IsItInt()
        {
            var expected = "+-1*x^2+-2*x+-10";
            var trueParametr = -10;
            var parametr = EquationSolver.ParsingEquation.GetParametr(expected);
            Assert.AreEqual(trueParametr, parametr);
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
        public void Parametres_ItShouldbeDiscriminant()
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
        public void ParametresandDiscriminant_X1()
        {
            int[] parametres = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculation.GetDiscriminant(parametres);
            double actual = EquationSolver.RootsFinder.GetX1(parametres, discriminant);
            Assert.AreEqual(3, actual);
        }
        [TestMethod]
        public void ParametresandDiscriminant_X2()
        {
            int[] parametres = { 2, -8, 6 };
            int discriminant = EquationSolver.DiscriminantCalculation.GetDiscriminant(parametres);
            double actual = EquationSolver.RootsFinder.GetX2(parametres, discriminant);
            Assert.AreEqual(1, actual);
        }
    }
        

    

}
