using System;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Infrastructure
{
    public interface IUserRepository
    {
        User LoadUser(Guid id);
        void SaveUser(User user);
        Guid GetGuidbyName(string name);
        bool CheckUserNicknameonSimilarity(string nickname);
        void Registrate(User user);
    }
}
