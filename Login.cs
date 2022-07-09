using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDSP
{
    public partial class Login : Form
    {
        int attempts;
        public Login()
        {
            InitializeComponent();
            roundCorners();
            usernameTB.Focus();
            attempts = 0;
        }

        private void roundCorners ()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, logoPictureBox.Width, logoPictureBox.Height);
            logoPictureBox.Region = new Region(path);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            attemptsLeft.Visible = false;
            if (attempts < 2)
            {
                string username, password;

                username = usernameTB.Text;
                password = passwordTB.Text;

                if (username == "Admin" && password == "SushilaDeviPS@0")
                {
                    //MessageBox.Show(this.MdiParent.ToString());
                    Main parentForm = (Main)this.MdiParent;
                    parentForm.approved = 1;
                    this.Close();
                }

                else if (username == "Teacher" && password == "sushiladevips")
                {
                    Main parentForm = (Main)this.MdiParent;
                    parentForm.approved = 2;
                    this.Close();
                }

                else
                {
                    attempts += 1;
                    DialogResult result = MessageBox.Show("Wrong Username or Password!", "Alert", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        usernameTB.Clear();
                        passwordTB.Clear();
                        usernameTB.Focus();
                        if (attempts > 0)
                        {
                            attemptsLeft.Visible = true;
                            attemptsLeft.Text = "Number of Attempts Remaining: " + (3 - attempts).ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBoxManager.OK = "Exit";
                MessageBoxManager.Register();
                MessageBox.Show("Too Many Wrong Attempts!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void showPasswordCB_CheckedChanged(object sender, EventArgs e)
        {
            passwordTB.PasswordChar = showPasswordCB.Checked ? '\0' : '*';
        }

        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //e.Handled = true;
                e.SuppressKeyPress = true;
                loginButton.PerformClick();
                //loginButton_Click(sender, e);
            }
        }

        private void usernameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //e.Handled = true;
                e.SuppressKeyPress = true;

                passwordTB.Focus();
                //SendKeys.Send("{Tab}");
            }
        }
    }
}
