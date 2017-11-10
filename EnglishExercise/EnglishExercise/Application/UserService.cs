using System;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainer.Application
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Registrate(string name)
        {
            var userId = Guid.NewGuid();
            var user = new User(name, userId,new LearnedWord[0]);
            if (!_userRepository.CheckUserNicknameonSimilarity(name))
                _userRepository.Registrate(user);
            return user;
        }
    }
}
