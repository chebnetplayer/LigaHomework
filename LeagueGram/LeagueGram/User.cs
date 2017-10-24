using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class User:IChatCreator
    {
        public User(string nickname)
        {
            _nickname = nickname;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string _nickname { get; }

        public void CreateChannel()
        {
            throw new NotImplementedException();
        }

        public void CreateGroup()
        {
            throw new NotImplementedException();
        }

        public void CreatePrivat()
        {
            throw new NotImplementedException();
        }
    }
}
