namespace EnglishTrainer.Domain
{
    public class LearnedWord:ILearnedWord
    {

        public void LearnWord()
        {
            Count++;
        }

        public LearnedWord(string englishWord)
        {
            EnglishWord = englishWord;
        }
        public readonly string EnglishWord;
        public int Count { get; private set; }

    }
}
