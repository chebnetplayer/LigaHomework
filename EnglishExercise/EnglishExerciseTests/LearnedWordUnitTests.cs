using System;
using EnglishTrainer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishTrainerTests
{
    [TestClass]
    public class LearnedWordUnitTests
    {
        [TestMethod]
        public void Word_IsWordLearned()
        {
            //arr
            var word = new LearnedWord("fuck");
            //act
            word.LearnWord();
            //ass
            Assert.IsTrue(word.Count==1);
        }
    }
}
