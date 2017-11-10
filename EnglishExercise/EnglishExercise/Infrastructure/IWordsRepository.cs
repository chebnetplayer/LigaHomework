using System.Collections.Generic;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Infrastructure
{
    public interface IWordsRepository
    {
        Dictionary<string, string> LoadWordsWithTranslate();
        Exercise GetExercise();
    }
}
