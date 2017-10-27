using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTests
{
    [TestClass]
    public class ChatRepositoryTests
    {
        [TestMethod]
        public void NewUser_IsUserCreated()
        {
            //arr
            var nick="nick";
            //act
            ChatRep.Registrate(nick);
            ChatRep.Registrate(nick);
            ChatRep.Registrate("l");
            var actual = ChatRep.Users[2].Nickname == "l";
            //ass
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void NewPrivateChat_IsChatCreated()
        {
            //arr
            ChatRep.Registrate("bars");
            ChatRep.Registrate("vasya");
            //act
            ChatRep.CreatePrivate("hay", ChatRep.Users[0].Id, ChatRep.Users[1].Id);
            //ass
            Assert.IsTrue(ChatRep.Chats[0].Chatname=="hay");
        }
        [TestMethod]
        public void NewChannel_IsChatCreated()
        {
            //arr
            ChatRep.Registrate("bars");
            //act
            ChatRep.CreateChannel("hay", ChatRep.Users[0].Id);
            //ass
            Assert.IsTrue(ChatRep.Chats[0].Chatname == "hay");
        }
        [TestMethod]
        public void NewGroup_IsChatCreated()
        {
            //arr
            ChatRep.Registrate("kenny");
            ChatRep.Registrate("vasya");
            ChatRep.Registrate("bars");
            var membersId = from i in ChatRep.Users select i.Id;
            //act
            ChatRep.CreateGroup("hay", ChatRep.Users[0].Id, membersId);
            //ass
            Assert.IsTrue(ChatRep.Chats[0].Chatname == "hay");
        }
    }
}
