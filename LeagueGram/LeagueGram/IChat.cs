using System;

namespace LeagueGram
{
    interface IChat
    {
        void SendMessage(Guid senderid,string text);
        void EditMessage(Guid messageid,string newtext,Guid whoedit);
        void DeleteMessege(Guid messageid, Guid whodelete);
        void InviteUser(User userid, User whoinvite);
        void DoMemberAdmin(Guid userid,Guid whodo);
        void DeleteMemberFromAdmin(Guid userid,Guid whodelete);
    }
}
