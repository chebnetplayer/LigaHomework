using System;
using System.Linq;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainer.Application
{
    public class ExerciseService:IExerciseService
    {
        public bool CheckAnswer(Exercise exercise, User user)
        {
            user.LearnWord(exercise.EnglishWord);
            if(exercise.IsCorrectAnswer()) _userRepository.SaveUser(user);
            return exercise.IsCorrectAnswer();
        }

        public LearnedWord[] GetLearnedWords(Guid userId)
        {
           return _userRepository.LoadUser(userId).LearnedWords.Where(i=>i.Count>3).ToArray();
        }

        public Exercise GetExercise(User user)
        {
            var exercise = _wordsRepository.GetExercise();
            while (user.CheckWordOnLearned(exercise.EnglishWord))
            {
                exercise = _wordsRepository.GetExercise();
            }
            return exercise;
        }

        private readonly IWordsRepository _wordsRepository;
        private readonly IUserRepository _userRepository;
        
        public ExerciseService(IWordsRepository wordsRepository, IUserRepository userRepository)
        {
            _wordsRepository = wordsRepository;
            _userRepository = userRepository;
        }
    }
}
