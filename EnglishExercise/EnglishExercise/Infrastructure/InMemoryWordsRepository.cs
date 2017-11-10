using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer.Domain;
using Newtonsoft.Json;

namespace EnglishTrainer.Infrastructure
{
    public class InMemoryWordsRepository : IWordsRepository
    {
        public Dictionary<string, string> LoadWordsWithTranslate()
        {
            var wordsWithTransalatesjson = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(wordsWithTransalatesjson);
        }

        public Exercise GetExercise()
        {
            var randomWord = GetRandomWord();
            var exercise=new Exercise(randomWord.Key, GetVariants(randomWord.Key).ToArray(), randomWord.Value);
            return exercise;
        }

        private KeyValuePair<string, string> GetRandomWord()
        {
            return _wordsWithTranslate.ElementAt(new Random().Next(_wordsWithTranslate.Count));
        }

        private List<string> GetVariants(string englishword)
        {
            var variants = new List<string>();
            while (variants.Count != 2)
            {
                var randomword = GetRandomWord();
                if(randomword.Key!=englishword && !variants.Contains(randomword.Value))
                    variants.Add(randomword.Value);
            }
            variants.Add(_wordsWithTranslate[englishword]);
            return variants;
        }

        public InMemoryWordsRepository()
        {
            _path = @"words.json";
            _wordsWithTranslate = LoadWordsWithTranslate();
        }
        private readonly string _path;
        private readonly Dictionary<string, string> _wordsWithTranslate;

    }
}
