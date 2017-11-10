using System;
using System.Linq;
using System.Windows.Forms;
using EnglishTrainer.Application;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;

namespace EnglishExerciseWinForms
{
    public partial class ExerciseForm : Form
    {
        public ExerciseForm()
        {
            InitializeComponent();
           
        }

        private void GetVariants(Exercise exercise)
        {
            EnglishwordtextBox.Text = exercise.EnglishWord;
            var buttons = Controls.OfType<Button>();
            SortArray(ref exercise);
            var buttonslist = buttons.ToList();
            buttonslist.Remove(LearnedWordsbutton);
            for (var i = 0; i < buttonslist.Count; i++)
            {
                buttonslist[i].Text = exercise.RussianWords[i];
            }
        }

        private static void SortArray(ref Exercise exercise)
        {
            var random = new Random();
            for (var i = exercise.RussianWords.Length - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                var temp = exercise.RussianWords[j];
                exercise.RussianWords[j] = exercise.RussianWords[i];
                exercise.RussianWords[i] = temp;
            }
        }
        private void ExerciseForm_Load(object sender, EventArgs e)
        {
            _mainUser = LoginForm.MainUser;
            var exercise = _exerciseService.GetExercise(_mainUser);
            _exercise = exercise;
            GetVariants(exercise);          
        }

        private readonly ExerciseService _exerciseService = new ExerciseService(
            new InMemoryWordsRepository(),new InMemoryUserRepository());

        private static User _mainUser;
        private static Exercise _exercise;
        private void FirstVariantbutton_Click(object sender, EventArgs e)
        {
            _exercise.Answer = FirstVariantbutton.Text;
            MessageBox.Show(_exerciseService.CheckAnswer(_exercise, _mainUser) ? "Correct" : "Wrong");
            var exercise = _exerciseService.GetExercise(_mainUser);
            _exercise = exercise;
            GetVariants(exercise);
        }

        private void SecondVariantbutton_Click(object sender, EventArgs e)
        {
            _exercise.Answer = SecondVariantbutton.Text;
            MessageBox.Show(_exerciseService.CheckAnswer(_exercise, _mainUser) ? "Correct" : "Wrong");
            var exercise = _exerciseService.GetExercise(_mainUser);
            _exercise = exercise;
            GetVariants(exercise);
        }

        private void ThirdVariantbutton_Click(object sender, EventArgs e)
        {
            _exercise.Answer = ThirdVariantbutton.Text;
            MessageBox.Show(_exerciseService.CheckAnswer(_exercise, _mainUser) ? "Correct" : "Wrong");
            var exercise = _exerciseService.GetExercise(_mainUser);
            _exercise = exercise;
            GetVariants(exercise);
        }

        private void LearnedWordsbutton_Click(object sender, EventArgs e)
        {
            var words = _exerciseService.GetLearnedWords(_mainUser.Id);
            LearnedWordsrichTextBox.Text = "";
            foreach (var i in words)
            {
                LearnedWordsrichTextBox.Text += i.EnglishWord+Environment.NewLine;
            }
        }
    }
}
