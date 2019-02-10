using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AuthApp.Core.Models;
using AuthApp.Core;

namespace AuthApp.View
{
    public partial class HomePage : Form
    {
        public HomePage(ApplicationUser user)
        {
            InitializeComponent();
            UserNameLabel.Text = user.FirstName + " " + user.LastName;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Singleton.getInstance().User = null;
            this.Hide();
            var startPage = new Start();
            startPage.Show();
        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
