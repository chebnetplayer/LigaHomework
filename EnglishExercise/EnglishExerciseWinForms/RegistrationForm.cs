using System;
using System.Windows.Forms;
using EnglishTrainer.Application;
using EnglishTrainer.Infrastructure;

namespace EnglishExerciseWinForms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Registrationbutton_Click(object sender, EventArgs e)
        {
            _userService.Registrate(NicknametextBox.Text);
            Close();
        }

        private UserService _userService=new UserService(new InMemoryUserRepository());
    }
}
