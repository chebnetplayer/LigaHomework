using System;

namespace LeagueGram
{
    public class Channel : Chat
    {
        public Channel(string chatname, User host) : base(chatname, host)
        {
            ChatType = ChatType.Channel;
        }
        public override void SendMessage(Guid senderid, string text)
        {
            if(senderid == Host.Id)
                base.SendMessage(Host.Id, text);
        }
    }
}
