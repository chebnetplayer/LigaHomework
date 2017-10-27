using System;

namespace LeagueGram
{
    internal interface IChat
    {
        void SendMessage(Guid senderid,string text);
        void EditMessage(Guid messageid,string newtext,Guid initiatorMemberId);
        void DeleteMessege(Guid messageid, Guid initiatorMemberId);
        void InviteUser(User targetUser, Guid initiatorMemberId);
        void PromoteMemberToAdmin(Guid targetMemberId,Guid initiatorMemberId);
        void DeleteMemberFromAdmin(Guid targetMemberId,Guid initiatorMemberId);
    }
}
