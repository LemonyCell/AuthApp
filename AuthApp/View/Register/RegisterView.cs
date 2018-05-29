using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AuthApp.Models.BindingModel;
using AuthApp.Service;

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
    }
}
