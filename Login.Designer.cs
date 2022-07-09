
namespace SDSP
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.showPasswordCB = new System.Windows.Forms.CheckBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.attemptsLeft = new System.Windows.Forms.Label();
            this.schoolNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(261, 27);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(192, 192);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // usernameTB
            // 
            this.usernameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameTB.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTB.Location = new System.Drawing.Point(611, 336);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(2);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(290, 39);
            this.usernameTB.TabIndex = 1;
            this.usernameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTB_KeyDown);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(429, 339);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(150, 32);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username:";
            // 
            // showPasswordCB
            // 
            this.showPasswordCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showPasswordCB.AutoSize = true;
            this.showPasswordCB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPasswordCB.Location = new System.Drawing.Point(435, 563);
            this.showPasswordCB.Margin = new System.Windows.Forms.Padding(2);
            this.showPasswordCB.Name = "showPasswordCB";
            this.showPasswordCB.Size = new System.Drawing.Size(145, 23);
            this.showPasswordCB.TabIndex = 3;
            this.showPasswordCB.Text = "Show Password";
            this.showPasswordCB.UseVisualStyleBackColor = true;
            this.showPasswordCB.CheckedChanged += new System.EventHandler(this.showPasswordCB_CheckedChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(429, 407);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(150, 32);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTB
            // 
            this.passwordTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTB.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.Location = new System.Drawing.Point(611, 404);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(2);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(290, 39);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTB_KeyDown);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackColor = System.Drawing.Color.LightSalmon;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(800, 548);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(101, 45);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "LOGIN";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // attemptsLeft
            // 
            this.attemptsLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attemptsLeft.AutoSize = true;
            this.attemptsLeft.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attemptsLeft.ForeColor = System.Drawing.Color.Maroon;
            this.attemptsLeft.Location = new System.Drawing.Point(738, 595);
            this.attemptsLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.attemptsLeft.Name = "attemptsLeft";
            this.attemptsLeft.Size = new System.Drawing.Size(224, 18);
            this.attemptsLeft.TabIndex = 7;
            this.attemptsLeft.Text = "Number of Attempts Left : 3";
            this.attemptsLeft.Visible = false;
            // 
            // schoolNameLabel
            // 
            this.schoolNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.schoolNameLabel.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolNameLabel.Location = new System.Drawing.Point(464, 47);
            this.schoolNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.schoolNameLabel.Name = "schoolNameLabel";
            this.schoolNameLabel.Size = new System.Drawing.Size(606, 153);
            this.schoolNameLabel.TabIndex = 8;
            this.schoolNameLabel.Text = "Sushila Devi Public School";
            this.schoolNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1331, 695);
            this.Controls.Add(this.schoolNameLabel);
            this.Controls.Add(this.attemptsLeft);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.showPasswordCB);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(964, 592);
            this.Name = "Login";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.CheckBox showPasswordCB;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label attemptsLeft;
        private System.Windows.Forms.Label schoolNameLabel;
    }
}