using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueGram
{
    public abstract class Chat : IChat
    {
        public void DeleteMemberFromAdmin(Guid userid, Guid whodelete)
        {
            if (whodelete != Host.Id) return;
            var membersList = Members.ToList();           
            var adminsList = Admins.ToList();
            var memberIndex = adminsList.FindIndex(i => i.Id == userid);
            adminsList.Add(adminsList[memberIndex]);
            membersList.Remove(membersList[memberIndex]);
            Members = membersList.ToArray();
            Admins = adminsList.ToArray();
        }
        public void DeleteMessege(Guid messageid, Guid whodelete)
        {
            var msglist = Messages.ToList();
            var msgIndex = msglist.FindIndex(i => i.Id == messageid);
            if (msglist[msgIndex].SenderId != whodelete) return;
            msglist.Remove(msglist[msgIndex]);
            Messages = msglist.ToArray();
        }
        public void DoMemberAdmin(Guid userid, Guid whodo)
        {
            var membersList = Members.ToList();
            var adminsList = Admins.ToList();
            var memberIndex = membersList.FindIndex(i => i.Id == userid);
            if ((whodo != Host.Id) && (whodo != adminsList.Find(i => i.Id == whodo).Id)) return;
            adminsList.Add(membersList[memberIndex]);
            membersList.Remove(membersList[memberIndex]);
            Members = membersList.ToArray();
            Admins = adminsList.ToArray();
        }

        public void EditMessage(Guid messageid, string newtext, Guid whoedit)
        {
            var member = GetMemberFromChat().Find(i=>i.Id==whoedit);
            if (member.Id != whoedit) return;
            {
                var msglist = Messages.ToList();
                var msgindex = msglist.FindIndex(i => i.Id == messageid);
                if (msglist[msgindex].SenderId == whoedit)
                    msglist[msgindex].EditMessage(newtext);
                Messages = msglist.ToArray();
            }
        }
        public void InviteUser(User userid, User whoinvite)
        {
            if (!IsMemberHasAdminRules(whoinvite)) return;
            var memberslist = Members.ToList();
            memberslist.Add(userid);
            Members = memberslist.ToArray();
        }
        public virtual void SendMessage(Guid senderid, string text)
        {
            var msg = new Message(text, senderid);
            var msglist = Messages.ToList();
            msglist.Add(msg);
            Messages = msglist.ToArray();
        }
        public Chat(string chatname, User host)
        {
            Chatname = chatname;
            Id = Guid.NewGuid();
            Host = host;
        }
        public bool IsMemberHasAdminRules(User member)
        {
            return Admins.Contains(member)||member==Host;
        }

        private List<User> GetMemberFromChat()
        {
            var chatmembers = new List<User>();
            chatmembers.AddRange(Members);
            chatmembers.AddRange(Admins);
            chatmembers.Add(Host);
            return chatmembers;
        }
        public Message[] Messages { get; private set; }
        public User[] Members { get; private set; }
        public User[] Admins { get; private set; }
        public User Host { get; }
        public Guid Id { get; }
        public string Chatname { get; }
    }
}
