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
        class Class1 : GroupBox
        {
        Label label { get; set; }
        TextBox textBox { get; set; }

        public Class1(string fieldName)
        {
            Initial(fieldName);
        }

        public void Initial(string fieldName)
        {
            this.Name = fieldName + "Groupbox";

            label = new Label();
            label.Text = fieldName;
            label.Name = fieldName + "Label";
            this.Controls.Add(label);
            textBox = new TextBox();
            textBox.Name = fieldName + "TextBox";
            this.Controls.Add(textBox);
        }

        }
    }