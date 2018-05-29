namespace AuthApp.View
{
    partial class HomePage
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
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.AccauntPictureBox = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccauntPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(12, 359);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(207, 25);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "Анонімний Онаніст";
            this.UserNameLabel.Click += new System.EventHandler(this.UserNameLabel_Click);
            // 
            // AccauntPictureBox
            // 
            this.AccauntPictureBox.Image = global::AuthApp.Properties.Resources._1_AccauntPhoto;
            this.AccauntPictureBox.Location = new System.Drawing.Point(12, 12);
            this.AccauntPictureBox.Name = "AccauntPictureBox";
            this.AccauntPictureBox.Size = new System.Drawing.Size(241, 308);
            this.AccauntPictureBox.TabIndex = 2;
            this.AccauntPictureBox.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(688, 401);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 37);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.AccauntPictureBox);
            this.Name = "HomePage";
            this.Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.AccauntPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.PictureBox AccauntPictureBox;
        private System.Windows.Forms.Button ExitButton;
    }
}