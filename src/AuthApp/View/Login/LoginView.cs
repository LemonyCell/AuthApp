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

namespace AuthApp.View.Login
{
    public partial class LoginView : Form
    {
        public readonly AccountService _accountService;
        public readonly ValidationService _validationService;

        public LoginView()
        {
            InitializeComponent();
            _accountService = new AccountService();
            _validationService = new ValidationService();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var model = new AuthBindingModel();
            //+ поля
            model.Login = LoginTextBox.Text;
            model.Password = PasswordTextBox.Text;

            var validation = _validationService.Validation(model);
            if (!validation.Success)
            {
                MessageBox.Show(validation.Error.ErrorDescription);
                return;
            }

            var result = _accountService.Login(model);
            if (!result.Success)
            {
                MessageBox.Show(result.Error.ErrorDescription);
                return;
            }
            if (result.Success)
            {
                this.Hide();
                var homePage = new HomePage(result.Result);
                homePage.Show();
            }
        }
    }
}
