using System;
using System.Windows.Forms;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;

namespace EnglishExerciseWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Loginlabel_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var exerciseform=new ExerciseForm();
            MainUser=_userRepository.LoadUser(_userRepository.GetGuidbyName(LogIntextBox.Text));
            if (MainUser == null) return;
            exerciseform.Activate();
            exerciseform.Visible = true;
            Hide();
        }

        private void Registrationbutton_Click(object sender, EventArgs e)
        {
            var registrationForm=new RegistrationForm();
            registrationForm.Activate();
            registrationForm.Visible = true;
        }
        internal static User MainUser { get; private set; }
        private InMemoryUserRepository _userRepository=new InMemoryUserRepository();
    }
}
