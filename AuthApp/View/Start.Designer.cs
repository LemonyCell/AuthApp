namespace AuthApp.View
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.LogInButton = new System.Windows.Forms.Button();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(203, 250);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(407, 41);
            this.RegistrationButton.TabIndex = 3;
            this.RegistrationButton.Text = "Registration";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.Registration_Click);
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(203, 170);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(407, 41);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "LogIn";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.ConnectionLabel.Location = new System.Drawing.Point(198, 319);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(191, 29);
            this.ConnectionLabel.TabIndex = 4;
            this.ConnectionLabel.Text = "connection done";
            this.ConnectionLabel.Visible = false;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 460);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.LogInButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label ConnectionLabel;
    }
}

