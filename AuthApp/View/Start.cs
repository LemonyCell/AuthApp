using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthApp.Core.Service;
using AuthApp.View.Login;
using AuthApp.View.Register;

namespace AuthApp.View
{
    public partial class Start : Form
    {
        private readonly AccountService _accountService;

        public Start()
        {
            InitializeComponent();
            _accountService = new AccountService();
            SetConnection();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var Login = new LoginView();
            this.Hide();
            Login.Show();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            var Register = new RegisterView();
            this.Hide();
            Register.Show();
        }

        private void SetConnection()
        {
            var serviceResult = _accountService.SetConnection();
            if (serviceResult.Success)
            {
                ConnectionLabel.Text = "the connection is done";
                ConnectionLabel.ForeColor = Color.Green;
            }
            else
            {
                ConnectionLabel.Text = "the connection is failed";
                ConnectionLabel.ForeColor = Color.Red;
                LogInButton.Visible = false;
                RegistrationButton.Visible = false;
            }
            ConnectionLabel.Visible = true;
        }

    }
}
