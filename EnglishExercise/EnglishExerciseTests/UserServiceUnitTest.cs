using System;
using EnglishTrainer.Application;
using EnglishTrainer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishTrainerTests
{
    [TestClass]
    public class UserServiceUnitTest
    {
        [TestMethod]
        public void NewUser_IsUserRegistrated()
        {
            //arr
            const string nick = "lera";
            var userservice = new UserService(new InMemoryUserRepository());
            //act
            userservice.Registrate(nick);
            var id = new InMemoryUserRepository().GetGuidbyName(nick);
            //ass
            Assert.IsTrue(new InMemoryUserRepository().LoadUser(id).Name==nick);
        }
    }
}
