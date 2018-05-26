using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AuthApp.View.Login;
using AuthApp.View.Register;

namespace AuthApp.View
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
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
    }
}
