using System;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Application
{
    public interface IExerciseService
    {
        bool CheckAnswer(Exercise exercise,User user);
        LearnedWord[] GetLearnedWords(Guid userId);
        Exercise GetExercise(User user);
    }
}
