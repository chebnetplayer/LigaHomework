using System;

namespace LeagueGram
{
    internal interface IChatRep
    {
        void Registrate(string nickname);
        void CreatePrivate(string chatname, Guid hostid, Guid inviteUserid);
        void CreateChannel(string chatname, Guid hostid);
        void CreateGroup(string chatname, Guid hostid, Guid[] inviteUsersid);
        User LogIn(Guid userId);
    }
}
