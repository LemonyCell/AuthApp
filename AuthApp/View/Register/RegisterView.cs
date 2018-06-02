using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AuthApp.Core.Models.BindingModel;
using AuthApp.Core.Service;

namespace AuthApp.View.Register
{
    public partial class RegisterView : Form
    {
        public readonly AccountService _accountService;
        public readonly ValidationService _validationService;

        public RegisterView()
        {
            InitializeComponent();
            _accountService = new AccountService();
            _validationService = new ValidationService();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {

        }

        private void Register()
        {
            var model = new RegisterBindingModel();
            //+ поля
            model.FirstName = FirstNameTextBox.Text;
            model.LastName = LastNameTextBox.Text;
            model.Login = LoginTextBox.Text;
            model.PhoneNumber = PhoneNumberTextBox.Text;
            model.Password = PasswordTextBox.Text;
            model.Email = EmailTextBox.Text;

            var validation = _validationService.Validation(model);
            if (!validation.Success)
            {
                MessageBox.Show(validation.Error.ErrorDescription);
                return;
            }

            var result = _accountService.Register(model);
            if (!result.Success)
            {
                MessageBox.Show(result.Error.ErrorDescription);
                return;
            }
            if (result.Success)
            {
            this.Hide();
            var startPage = new Start();
            startPage.Show();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void RegistrationFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            var validation = _validationService.PhoneNumberValidation(PhoneNumberTextBox.Text);
            if (validation.Success)
            {
                PhoneNumberCheckLabel.ForeColor = Color.Green;
                PhoneNumberCheckLabel.Text = "Done";
            }
            else
            {
                PhoneNumberCheckLabel.ForeColor = Color.Red;
                PhoneNumberCheckLabel.Text = "Error";
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            var validation = _validationService.EmailValidation(EmailTextBox.Text);
            if (validation.Success)
            {
                EmailCheckLabel.ForeColor = Color.Green;
                EmailCheckLabel.Text = "Done";
            }
            else
            {
                EmailCheckLabel.ForeColor = Color.Red;
                EmailCheckLabel.Text = "Error";
            }

        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var validation = _validationService.NameValidation(FirstNameTextBox.Text);
            if (validation.Success)
            {
                FirstNameCheckLabel.ForeColor = Color.Green;
                FirstNameCheckLabel.Text = "Done";
            }
            else
            {
                FirstNameCheckLabel.ForeColor = Color.Red;
                FirstNameCheckLabel.Text = "Error";
            }
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var validation = _validationService.NameValidation(LastNameTextBox.Text);
            if (validation.Success)
            {
                LastNameCheckLabel.ForeColor = Color.Green;
                LastNameCheckLabel.Text = "Done";
            }
            else
            {
                LastNameCheckLabel.ForeColor = Color.Red;
                LastNameCheckLabel.Text = "Error";
            }
        }

        private void ChangeCheckLabel(TextBox label, Label check)
        {
            var validation = _validationService.FieldValidation(label.Text);
            if (validation.Success)
            {
                check.ForeColor = Color.Green;
                check.Text = "Done";
            }
            else
            {
                check.ForeColor = Color.Red;
                check.Text = "Error";
            }
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeCheckLabel(LoginTextBox, LoginCheckLabel);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeCheckLabel(PasswordTextBox, PasswordCheckLabel);
        }
    }
}
