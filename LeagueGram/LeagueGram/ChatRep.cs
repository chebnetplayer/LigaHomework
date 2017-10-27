using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueGram
{
    public class ChatRep:IChatRep
    {
        public static Chat[] Chats { get; private set; }
        public static User[] Users { get; private set; }

        static ChatRep()
        {
            Chats=new Chat[0];
            Users=new User[0];
        }
        public static void CreatePrivate(string chatname, Guid hostid, Guid inviteUserid)
        {
            var chatslist = Chats.ToList();
            var host = Users.First(i => i.Id == hostid);
            var inviteUser = Users.First(i => i.Id == inviteUserid);
            var newprivatechat=new PrivateChat(chatname, host, inviteUser);
            chatslist.Add(newprivatechat);
            Chats = chatslist.ToArray();
        }

        public static void CreateChannel(string chatname, Guid hostid)
        {
            if (Chats == null) Chats = new Chat[0];
            var chatslist = Chats.ToList();
            var host = Users.First(i => i.Id == hostid);
            var newchannel = new Channel(chatname, host);
            chatslist.Add(newchannel);
            Chats = chatslist.ToArray();
        }

        public static void CreateGroup(string chatname, Guid hostid, IEnumerable<Guid> inviteUsersid)
        {
            var chatslist = Chats.ToList();
            var host = Users.First(i => i.Id == hostid);
            var newgroup = new Group(chatname, host, inviteUsersid.Select(variable => Users.First(i => i.Id == variable)).ToArray());
            chatslist.Add(newgroup);
            Chats = chatslist.ToArray();
        }

        public static User LogIn(Guid userId)
        {
            var user = Users.First(i => i.Id == userId);
            return user;
        }

        public static void Registrate(string nickname)
        {
            var userslist = Users.ToList();
            var user = new User(nickname, Guid.NewGuid());
            userslist.Add(user);
            Users = userslist.ToArray();
        }

        public static Chat GetChat(Guid chatId)
        {
            return Chats.First(i => i.Id == chatId);
        }

        void IChatRep.Registrate(string nickname)
        {
            Registrate(nickname);
        }

        void IChatRep.CreatePrivate(string chatname, Guid hostid, Guid inviteUserid)
        {
            CreatePrivate(chatname, hostid, inviteUserid);
        }

        void IChatRep.CreateChannel(string chatname, Guid hostid)
        {
            CreateChannel(chatname, hostid);
        }

        void IChatRep.CreateGroup(string chatname, Guid hostid, Guid[] inviteUsersid)
        {
            CreateGroup(chatname, hostid, inviteUsersid);
        }

        User IChatRep.LogIn(Guid userId)
        {
            return LogIn(userId);
        }
    }
}
