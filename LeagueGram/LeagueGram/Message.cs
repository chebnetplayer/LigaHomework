using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
        public string Text { get; }
        public Guid Id { get; }
        public Guid SenderId { get; }

    }
}
