using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    class PrivateChat : Chat
    {
        public PrivateChat(string chatname, User host, User member) : base(chatname, host)
        {

        }
    }
}
