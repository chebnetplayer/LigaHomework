using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    interface IChat
    {
        void SendMessage(Guid senderid,string text);
        void EditMessage(Guid messageid,string newtext,Guid whoedit);
        void DeleteMessege(Guid messageid, Guid whodelete);
        void InviteUser(Guid userid, Guid whoinvite);
        void DoMemberAdmin(Guid userid);
        void DeleteMemberFromAdmin(Guid userid);
    }
}
