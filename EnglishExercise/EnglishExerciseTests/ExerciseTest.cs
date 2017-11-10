using System;
using EnglishTrainer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishTrainerTests
{
    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void BadAnswer_IsCorrectAnswer()
        {
            //arr
            var exercise = new Exercise("no", new[] {"да", "конечно", "нет"}, "нет") {Answer = "да"};
            //act
            var actual= exercise.IsCorrectAnswer();
            //ass
            Assert.IsFalse(actual);

        }
        [TestMethod]
        public void CorrectAnswer_IsCorrectAnswer()
        {
            //arr
            var exercise = new Exercise("no", new[] { "да", "конечно", "нет" }, "нет") { Answer = "нет" };
            //act
            var actual = exercise.IsCorrectAnswer();
            //ass
            Assert.IsTrue(actual);

        }
    }
}
