using System;
using EnglishTrainer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishTrainerTests
{
    [TestClass]
    public class UserUnitTests
    {
        [TestMethod]
        public void Englishword_IswordLearned()
        {
            //arr
            var user=new User("lol", Guid.NewGuid(), new LearnedWord[0]);
            //act
            user.LearnWord("back");
            //ass
            Assert.IsTrue(user.LearnedWords[0].EnglishWord=="back");
        }

        [TestMethod]
        public void EnglishLearnedWord_IsWordCheckedonLearning()
        {
            //arr
            var user = new User("lol", Guid.NewGuid(),
                new []{new LearnedWord("back") });
            for(var i=0;i<4;i++)
                user.LearnedWords[0].LearnWord();
            //act
            var actual = user.CheckWordOnLearned("back");
            //ass
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void English_IsWordCheckedonLearning()
        {
            //arr
            var user = new User("lol", Guid.NewGuid(), new LearnedWord[0]);
            //act
            var actual = user.CheckWordOnLearned("back");
            //ass
            Assert.IsFalse(actual);
        }
    }
}
