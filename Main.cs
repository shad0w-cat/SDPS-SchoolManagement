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
    public partial class Main : Form
    {
        public int approved = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            //Login loginSession = new Login();

            //loginSession.MdiParent = this;
            //loginSession.TopMost = false;
            //loginSession.Show();

            if (approved == 1 || approved == 2)
            {
                Home currentSession = new Home(approved);
                currentSession.MdiParent = this;
                currentSession.TopMost = false;
                currentSession.Show();
            }
        }
    }
}
