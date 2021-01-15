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
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Username: " + textBox1.Text);
            // TODO add atuh logic here
            Login parent = (Login)this.Parent;
            MainWindow newForm = new MainWindow();
            parent.Hide();
            newForm.Show();
        }
    }
}
