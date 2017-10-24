using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    class Group : Chat
    {
        public Group(string chatname, User host) : base(chatname, host)
        {
        }
    }
}
