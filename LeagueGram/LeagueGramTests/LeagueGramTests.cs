using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTests
{
    [TestClass]
    public class LeagueGramTests
    {
        [TestMethod]
        public void Userid_IsUserLoginned()
        {
            //arr
            ChatRep.Registrate("bars");
            var id = ChatRep.Users[0].Id;
            //act
            LiagueGram.LogIn(id);
            //ass
            Assert.IsTrue(LiagueGram.User.Nickname=="bars");
        }

        [TestMethod]
        public void Message_IsMessageSended()
        {
            //arr
            ChatRep.Registrate("bars");
            ChatRep.Registrate("volk");
            LiagueGram.LogIn(ChatRep.Users[0].Id);
            ChatRep.CreatePrivate("chatik",LiagueGram.User.Id,ChatRep.Users[1].Id);
            //act
            LiagueGram.SendMessage("HI",ChatRep.Chats[0].Id);
            //ass
            Assert.IsTrue(ChatRep.Chats[0].Messages[0].Text=="HI");
        }

        [ExpectedException(typeof(IndexOutOfRangeException)), TestMethod]
        public void Message_IsMessageNoneSended()
        {
            //arr
            ChatRep.Registrate("bars");
            ChatRep.Registrate("volk");
            LiagueGram.LogIn(ChatRep.Users[0].Id);
            ChatRep.CreateChannel("chatik", LiagueGram.User.Id);
            LiagueGram.InviteUser(ChatRep.Chats[0].Id, ChatRep.Users[1].Id);
            //act
            LiagueGram.SendMessage("HI", ChatRep.Chats[1].Id);
            //ass
            var text = ChatRep.Chats[0].Messages[0].Text;
        }

        [TestMethod]
        public void UserId_IsuserInvitedinChat()
        {
            //arr
            ChatRep.Registrate("bars");
            ChatRep.Registrate("volk");
            ChatRep.Registrate("mraz");
            LiagueGram.LogIn(ChatRep.Users[0].Id);
            LiagueGram.CreateGroup("chatik", new[] {ChatRep.Users[1].Id});
            //act
            LiagueGram.InviteUser(ChatRep.Chats[0].Id,ChatRep.Users[2].Id);
            //ass
            Assert.IsTrue(ChatRep.Users[2].Nickname=="mraz");
        }

        [ExpectedException(typeof(IndexOutOfRangeException)), TestMethod]
        public void UserId_IsuserNoneInvitedinChat()
        {
            //arr
            ChatRep.Registrate("bars");
            ChatRep.Registrate("volk");
            ChatRep.Registrate("mraz");
            LiagueGram.LogIn(ChatRep.Users[0].Id);
            ChatRep.CreateGroup("chatik",ChatRep.Users[1].Id, new[] { ChatRep.Users[2].Id });
            //act
            LiagueGram.InviteUser(ChatRep.Chats[1].Id, ChatRep.Users[2].Id);
            //ass
            var nick= ChatRep.Users[2].Nickname;
        }
    }
}
