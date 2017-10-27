using System.Collections.Generic;
using System.Linq;

namespace LeagueGram
{
    public class Group : Chat
    {
        public Group(string chatname, User host,IEnumerable<User> inviteUsers) : base(chatname, host)
        {
            ChatType = ChatType.Group;
            var memberslist = Members.ToList();
            memberslist.AddRange(inviteUsers.Where(i => !CheckUserOnParticipationinChat(i.Id)));
            Members = memberslist.ToArray();
        }
    }
}
