namespace EnglishTrainer.Domain
{
    public class Exercise:IExercise
    {
        public bool IsCorrectAnswer()
        {
            return Answer == CorrectRussianWord;
        }
        public readonly string EnglishWord;
        public readonly string CorrectRussianWord;
        public readonly string[] RussianWords;
        public string Answer;
        public Exercise(string englishWord, string[] russianWords, string correctRussianWord)
        {
            EnglishWord = englishWord;
            RussianWords = russianWords;
            CorrectRussianWord = correctRussianWord;
        }
    }
}
