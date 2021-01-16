using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESToran.PresentationLayer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            userControl11.Hide();
            registerControl1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registerControl1.Visible)
            {
                registerControl1.Hide();
            }

            if (userControl11.Visible)
            {
                userControl11.Hide();
            }
            else
            {
                userControl11.Show();
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userControl11.Visible)
            {
                userControl11.Hide();
            }
            if (registerControl1.Visible)
            {
                registerControl1.Hide();
            }
            else
            {
                registerControl1.Show();
            }
        }

        private void registerControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
