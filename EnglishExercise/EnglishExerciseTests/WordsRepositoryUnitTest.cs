using System;
using System.IO;
using EnglishTrainer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace EnglishTrainerTests
{
    [TestClass]
    public class WordsRepositoryUnitTest
    {
        private readonly IWordsRepository _wordsRepository = new InMemoryWordsRepository();
        [TestMethod]
        public void WordsDictionary_LoadWordsWithTranslate()
        {
            //arr
            var expected = File.ReadAllText(@"words.json");
            //act
            var actual = JsonConvert.SerializeObject(_wordsRepository.LoadWordsWithTranslate());
            //ass
            Assert.IsTrue(actual==expected);
        }
    }
}
