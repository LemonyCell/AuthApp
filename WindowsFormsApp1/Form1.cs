using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = flowLayoutPanel1;
            Class1 cl = new Class1("Name");
            Class1 cl1 = new Class1("Age");
            panel.Controls.Add(cl);
            panel.Controls.Add(cl1);
        }
    }
}
