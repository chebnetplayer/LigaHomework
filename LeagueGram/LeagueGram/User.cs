using System;

namespace LeagueGram
{
    public class User
    {
        public User(string nickname,Guid id)
        {
            Nickname = nickname;
            Id = id;
        }
        public Guid Id { get; }
        public string Nickname { get; }
    }
}
