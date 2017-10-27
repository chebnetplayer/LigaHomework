using System;
using System.Linq;

namespace LeagueGram
{
    public class PrivateChat : Chat
    {
        public PrivateChat(string chatname, User host, User member) : base(chatname, host)
        {
            ChatType = ChatType.PrivateChat;
            var memberslist = Members.ToList();
            if(!CheckUserOnParticipationinChat(member.Id))
                memberslist.Add(member);
            Members = memberslist.ToArray();
        }

        public override void InviteUser(User targetUser, Guid initiatorMemberId)
        {
            if(Members.Length==0)
                base.InviteUser(targetUser, initiatorMemberId);
        }
    }
}
