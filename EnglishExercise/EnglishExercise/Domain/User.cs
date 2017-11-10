using System;
using System.Linq;

namespace EnglishTrainer.Domain
{
    public class User:IUser
    {
        public bool CheckWordOnLearned(string word)
        {
            return LearnedWords.Any(i => i.EnglishWord == word && i.Count >= 3);
        }

        public void LearnWord(string word)
        {
            var learnedwordslist = LearnedWords.ToList();
            var learnedword = learnedwordslist.FirstOrDefault(i => i.EnglishWord == word) ?? new LearnedWord(word);
            learnedword.LearnWord();
            if(!learnedwordslist.Contains(learnedword))
                learnedwordslist.Add(learnedword);
            LearnedWords = learnedwordslist.ToArray();
        }

        public User(string name, Guid id, LearnedWord[] learnedWords)
        {
            Id = id;
            Name = name;
            LearnedWords = learnedWords;
        }

        public string Name { get; }
        public Guid Id { get; }
        public LearnedWord[] LearnedWords { get; private set; }

    }
}
