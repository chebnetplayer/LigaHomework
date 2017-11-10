using System;
using System.Text;
using System.Collections.Generic;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishTrainerTests
{
    [TestClass]
    public class UserRepositoryUnitTest
    {
        private IUserRepository _userRepository=new InMemoryUserRepository();
        [TestMethod]
        public void Name_GetGuidbyName()
        {
            //arr
            const string name = "admin";
            //act
            var user = _userRepository.LoadUser(_userRepository.GetGuidbyName(name));
            //ass
            Assert.IsTrue(user.Name==name);
        }

        [TestMethod]
        public void Name_CheckUserNicknameonSimilarity()
        {
            //arr
            const string expected = "lera";
            //act
            var actual = _userRepository.CheckUserNicknameonSimilarity(expected);
            //ass
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void User_IsUserRegistrated()
        {
            //arr
            var user=new User("paha",Guid.NewGuid(), new LearnedWord[0]);
            //act
            _userRepository.Registrate(user);
            //ass
            Assert.IsTrue(_userRepository.GetGuidbyName(user.Name)==user.Id);
        }

        [TestMethod]
        public void User_IsUserSaved()
        {
            //arr
            var user = _userRepository.LoadUser(_userRepository.GetGuidbyName("paha"));
            //act
            user.LearnWord("BOB");
            _userRepository.SaveUser(user);
            //ass
            Assert.IsTrue(_userRepository.LoadUser(user.Id).LearnedWords.Length == 1);
        }
    }
}
