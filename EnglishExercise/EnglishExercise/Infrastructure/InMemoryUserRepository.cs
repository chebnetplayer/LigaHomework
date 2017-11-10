using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer.Domain;
using Newtonsoft.Json;

namespace EnglishTrainer.Infrastructure
{
    public class InMemoryUserRepository:IUserRepository
    {
        public Guid GetGuidbyName(string name)
        {
            var usersJson = File.ReadAllText(_path);
            _users = JsonConvert.DeserializeObject<Dictionary<Guid, User>>(usersJson);
            var user = _users.FirstOrDefault(i => i.Value.Name == name);
            return user.Value == null ? default(Guid) : user.Key;
        }
        public User LoadUser(Guid id)
        {
            return !_users.ContainsKey(id) ? null : _users[id];
        }

        public bool CheckUserNicknameonSimilarity(string nickname)
        {
            return _users.Any(i => nickname == i.Value.Name);
        }

        public void Registrate(User user)
        {
            _users.Add(user.Id,user);
            var usersJson = JsonConvert.SerializeObject(_users);
            File.WriteAllText(_path, usersJson);           
        }
        public void SaveUser(User user)
        {
            _users[user.Id] = user;
            var usersJson = JsonConvert.SerializeObject(_users);
            File.WriteAllText(_path, usersJson);
        }
        public InMemoryUserRepository()
        {
            _path = @"users.json";
            var usersJson = File.ReadAllText(_path);
            _users= JsonConvert.DeserializeObject<Dictionary<Guid, User>>(usersJson) ?? new Dictionary<Guid, User>();
        }
        private Dictionary<Guid, User> _users;
        private readonly string _path;


    }
}
