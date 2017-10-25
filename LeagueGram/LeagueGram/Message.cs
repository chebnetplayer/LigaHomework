using System;

namespace LeagueGram
{
    public class Message : IMessage
    {
        public Message(string text, Guid senderId)
        {
            Text = text;
            SenderId = senderId;
            Id = Guid.NewGuid();
        }
        public void EditMessage(string newmessage)
        {
            Text = newmessage;
        }
        public string Text { get; private set; }
        public Guid Id { get; }
        public Guid SenderId { get; }

    }
}
