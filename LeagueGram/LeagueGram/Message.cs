using System;

namespace LeagueGram
{
    public class Message : IMessage
    {
        public Message(string text, Guid senderId, Guid id, DateTime dateTimeofSend)
        {
            Text = text;
            SenderId = senderId;
            Id = id;
            DateTimeofSend = dateTimeofSend;
        }
        public void EditMessage(string newmessage)
        {
            Text = newmessage;
        }
        public string Text { get; private set; }
        public  DateTime DateTimeofSend { get; }
        public Guid Id { get; }
        public Guid SenderId { get; }

    }
}
