using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class Chat : IChat
    {
        public void DeleteMemberFromAdmin(Guid userid)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessege(Guid messageid, Guid whodelete)
        {
            throw new NotImplementedException();
        }

        public void DoMemberAdmin(Guid userid)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(Guid messageid, string newtext, Guid whoedit)
        {
            throw new NotImplementedException();
        }

        public void InviteUser(Guid userid, Guid whoinvite)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Guid senderid, string text)
        {
            throw new NotImplementedException();
        }
        public Chat(string chatname, User host)
        {
            Chatname = chatname;
            Id = Guid.NewGuid();
            _host = host;
        }
        public Message[] _messages;
        public User _host { get; }
        public Guid Id { get; }
        public string Chatname { get; }
        public User[] _admins;
        public User[] _members;
    }
}
