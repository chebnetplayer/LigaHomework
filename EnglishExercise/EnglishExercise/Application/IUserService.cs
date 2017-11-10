using System;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Application
{
    public interface IUserService
    {
        User Registrate(string name);
    }
}
