using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;

namespace LeagueGramTests
{
    [TestClass]
    public class ChatTests
    {
        [TestMethod]
        public void ListOfAdmins_IsAdminDeletedFromList()
        {
            //arr
            var members= new[] {new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid())};
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.PromoteMemberToAdmin(members[0].Id, host.Id);
            group.PromoteMemberToAdmin(members[1].Id, host.Id);
            //act
            group.DeleteMemberFromAdmin(members[0].Id,host.Id);
            //ass
            Assert.IsTrue(group.Members[0].Id==members[0].Id);
        }
        [ExpectedException(typeof(IndexOutOfRangeException)),TestMethod]
        public void ListOfAdmins_IsAdminNoneDeletedFromList()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.PromoteMemberToAdmin(members[0].Id, host.Id);
            group.PromoteMemberToAdmin(members[1].Id, host.Id);
            //act
            group.DeleteMemberFromAdmin(members[0].Id, members[1].Id);
            //ass
            var id=group.Members[0].Id;
        }

        [TestMethod]
        public void ListOfMessages_IsMessageDeletedFromList()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.SendMessage(members[0].Id, "hello");
            group.SendMessage(members[1].Id, "hi");
            //act
            group.DeleteMessege(group.Messages[0].Id, members[0].Id);
            //ass
            Assert.IsTrue(group.Messages.Length==1);
        }
        [TestMethod]
        public void ListOfMessages_IsMessageNoneDeletedFromList()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.SendMessage(members[0].Id, "hello");
            group.SendMessage(members[1].Id, "hi");
            //act
            group.DeleteMessege(group.Messages[0].Id, members[1].Id);
            //ass
            Assert.IsTrue(group.Messages[0].Text=="hello");
        }

        [TestMethod]
        public void Message_IsMessageSended()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            //act
            group.SendMessage(members[0].Id, "hello");
            //ass
            Assert.IsTrue(group.Messages[0].Text=="hello");
        }
        [ExpectedException(typeof(IndexOutOfRangeException)), TestMethod]
        public void Message_IsMessageNoneSended()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var channel = new Channel("veselo", host);
            //act
            channel.SendMessage(members[0].Id, "hello");
            //ass
            var text = channel.Messages[0].Text;
        }
        [TestMethod]
        public void ListOfMember_IsMemberPromotedtoAdmin()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            //act
            group.PromoteMemberToAdmin(members[0].Id, host.Id);
            //ass
            Assert.IsTrue(group.Admins[0].Id==members[0].Id);
        }
        [ExpectedException(typeof(IndexOutOfRangeException)), TestMethod]
        public void ListOfMember_IsMemberNonePromotedtoAdmin()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            //act
            group.PromoteMemberToAdmin(members[0].Id, members[0].Id);
            //ass
            var name = group.Admins[0].Nickname;
        }
        [TestMethod]
        public void MessageId_IsMessageEdited()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.SendMessage(members[0].Id, "hello");
            group.SendMessage(members[1].Id, "hi");
            //act
            group.EditMessage(group.Messages[0].Id,"Good morning", members[0].Id);
            //ass
            Assert.IsTrue(group.Messages[0].Text== "Good morning");
        }

        [TestMethod]
        public void MessageId_IsMessageNoneEdited()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            group.SendMessage(members[0].Id, "hello");
            group.SendMessage(members[1].Id, "hi");
            //act
            group.EditMessage(group.Messages[0].Id, "Good morning", host.Id);
            //ass
            Assert.IsFalse(group.Messages[0].Text == "Good morning");
        }
        [TestMethod]
        public void User_IsUserInvitedInChat()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            var newmember=new User("kot",Guid.NewGuid());
            //act
            group.InviteUser(newmember,host.Id);
            //ass
            Assert.IsTrue(group.Members[group.Members.Length-1].Id==newmember.Id);
        }
        [TestMethod]
        public void User_IsUserNoneInvitedInChat()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            var newmember = new User("kot", Guid.NewGuid());
            //act
            group.InviteUser(newmember, group.Members[0].Id);
            //ass
            Assert.IsFalse(group.Members[group.Members.Length-1].Id == newmember.Id);
        }
        [TestMethod]
        public void UserthatwasInvited_IsUserNoneInvitedInChat()
        {
            //arr
            var members = new[] { new User("vasya", Guid.NewGuid()), new User("bilbo", Guid.NewGuid()) };
            var host = new User("bars", Guid.NewGuid());
            var group = new Group("veselo", host, members);
            var newmember = new User("kot", Guid.NewGuid());
            //act
            group.InviteUser(members[0],host.Id);
            //ass
            Assert.IsTrue(group.Members.Length==2);
        }
    }
}
