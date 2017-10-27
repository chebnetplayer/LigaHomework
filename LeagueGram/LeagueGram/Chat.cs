using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueGram
{
    public abstract class Chat : IChat
    {
        public void DeleteMemberFromAdmin(Guid targetMemberId, Guid initiatorMemberId)
        {
            var membersList = Members.ToList();      
            var adminsList = Admins.ToList();
            var member = GetAdmin(targetMemberId);
            if(member==null || initiatorMemberId != Host.Id)
                return;
            membersList.Add(member);
            adminsList.Remove(member);
            Members = membersList.ToArray();
            Admins = adminsList.ToArray();
        }
        public void DeleteMessege(Guid messageid, Guid initiatorMemberId)
        {
            var messageslist = Messages.ToList();
            var message = GetMessage(messageid);
            if(message==null || message.SenderId!=initiatorMemberId)
                return;
            messageslist.Remove(message);
            Messages = messageslist.ToArray();
        }
        public void PromoteMemberToAdmin(Guid targetMemberId, Guid initiatorMemberId)
        {
            var membersList = Members.ToList();
            var adminsList = Admins.ToList();
            var member = GetMember(targetMemberId);
            if(member==null || !IsMemberHasAdminRules(initiatorMemberId)) 
                return;
            adminsList.Add(member);
            membersList.Remove(member);
            Members = membersList.ToArray();
            Admins = adminsList.ToArray();
        }

        public void EditMessage(Guid messageid, string newtext, Guid initiatorMemberId)
        {
            var messageslist = Messages.ToList();
            var message = GetMessage(messageid);
            if (message==null || message.SenderId != initiatorMemberId)
                return;
            message.EditMessage(newtext);
            Messages = messageslist.ToArray();
        }
        public virtual void InviteUser(User targetUser, Guid initiatorMemberId)
        {
            if (!IsMemberHasAdminRules(initiatorMemberId) || CheckUserOnParticipationinChat(targetUser.Id))
                return;
            if (CheckUserOnParticipationinChat(targetUser.Id)) return;
            var memberslist = Members.ToList();
            memberslist.Add(targetUser);
            Members = memberslist.ToArray();
        }
        public virtual void SendMessage(Guid senderid, string text)
        {
            var message = new Message(text, senderid,Guid.NewGuid(),DateTime.Now);
            var messageslist = Messages.ToList();
            messageslist.Add(message);
            Messages = messageslist.ToArray();
        }
        private bool IsMemberHasAdminRules(Guid memberid)
        {
            var adminslist = Admins.ToList();
            adminslist.Add(Host);
            var admindGuids = from user in adminslist select user.Id;
            return admindGuids.Contains(memberid);
        }
        public List<User> GetMembersFromChat()
        {
            var chatmembers = new List<User>();
            chatmembers.AddRange(Members);
            chatmembers.AddRange(Admins);
            chatmembers.Add(Host);
            return chatmembers;
        }

        private User GetMember(Guid memberId)
        {
            if (Members.Length == 0) return null;
            var member = Members.FirstOrDefault(i => i.Id == memberId);
            return member;
        }

        private User GetAdmin(Guid adminid)
        {
            if (Admins.Length == 0) return null;
            var admin = Admins.FirstOrDefault(i => i.Id == adminid);
            return admin;
        }

        private Message GetMessage(Guid messageid)
        {
            if (Messages.Length == 0) return null;
            var message = Messages.FirstOrDefault(i => i.Id == messageid);
            return message;
        }

        protected bool CheckUserOnParticipationinChat(Guid targetUserId)
        {
            var allmembers = GetMembersFromChat();
            return allmembers.Any(i => i.Id == targetUserId);
        }
        protected Chat(string chatname, User host)
        {
            Chatname = chatname;
            Id = Guid.NewGuid();
            Host = host;
            Messages=new Message[0];
            Members=new User[0];
            Admins=new User[0];
        }
        public Message[] Messages { get; private set; }
        public User[] Members { get; protected set; }
        public User[] Admins { get; private set; }
        public User Host { get; }
        public Guid Id { get; }
        public ChatType ChatType { get; protected set; }
        public string Chatname { get; }
    }
}
