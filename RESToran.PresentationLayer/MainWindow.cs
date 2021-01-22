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
    public partial class MainWindow : Form
    {
        string AuthValue;
        public MainWindow()
        {
            InitializeComponent();
            FoodPressedPanel.Hide();
            ReservationsPressedPanel.Hide();
            TablesPressedPanel.Hide();
            ProfilePressedPanel.Hide();
            viewProfileControl1.Hide();
            editProfileControl1.Hide();
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Hide();
            viewTablesControl1.Hide();
            addTablesControl1.Hide();
            editTablesControl1.Hide();

        }

        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void FoodButton_Click(object sender, EventArgs e)
        {
            if (FoodPressedPanel.Visible)
            {
                FoodPressedPanel.Hide();
                MenuButtonPanel.Show();
            }
            else
            {
                FoodPressedPanel.Show();
                MenuButtonPanel.Hide();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FoodPressedPanel.Hide();
            MenuButtonPanel.Show();
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Hide();
        }


        private void FoodButton2_Click(object sender, EventArgs e)
        {
            FoodPressedPanel.Hide();
            MenuButtonPanel.Show();
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Hide();

        }

        private void ShowMenuButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.Hide();
            showMenuControl1.setAuthValue(AuthValue);
            showMenuControl1.Show();
            editMenuControl1.Hide();

        }

        private void EditMenuButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Show();
            editMenuControl1.setAuthValue(AuthValue);

        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.setAuthValue(AuthValue);
            addFoodControler1.Show();
            showMenuControl1.Hide();
            editMenuControl1.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void TablesButton2_Click(object sender, EventArgs e)
        {
            TablesPressedPanel.Hide();
            MenuButtonPanel.Show();
            addTablesControl1.Hide();
            editTablesControl1.Hide();

        }

        private void ViewTablesButton_Click(object sender, EventArgs e)
        {
            viewTablesControl1.Show();
            viewTablesControl1.setAuthValue(AuthValue);
            addTablesControl1.Hide();
            editTablesControl1.Hide();

        }

        private void ManageTablesButton_Click(object sender, EventArgs e)
        {
            viewTablesControl1.Hide();
            addTablesControl1.Hide();
            editTablesControl1.setAuthValue(AuthValue);
            editTablesControl1.Show();

        }

        private void AddTablesButton_Click(object sender, EventArgs e)
        {
            viewTablesControl1.Hide();
            addTablesControl1.Show();
            addTablesControl1.setAuthValue(AuthValue);
            editTablesControl1.Hide();

        }

        private void BackTablesButton_Click(object sender, EventArgs e)
        {
            TablesPressedPanel.Hide();
            MenuButtonPanel.Show();
            viewTablesControl1.Hide();
            addTablesControl1.Hide();
            editTablesControl1.Hide();

        }

        private void ReservationsButton2_Click(object sender, EventArgs e)
        {
            ReservationsPressedPanel.Hide();
            MenuButtonPanel.Show();
        }

        private void ViewReservationsButton_Click(object sender, EventArgs e)
        {

        }

        private void ManageReservationsButton_Click(object sender, EventArgs e)
        {

        }

        private void BackButton4_Click(object sender, EventArgs e)
        {
            ReservationsPressedPanel.Hide();
            MenuButtonPanel.Show();
        }

        private void TablesButton_Click(object sender, EventArgs e)
        {
            if (TablesPressedPanel.Visible)
            {
                TablesPressedPanel.Hide();
                MenuButtonPanel.Show();
            }
            else
            {
                TablesPressedPanel.Show();
                MenuButtonPanel.Hide();
            }
        }

        private void ReservationsButton_Click(object sender, EventArgs e)
        {
            if (ReservationsPressedPanel.Visible)
            {
                ReservationsPressedPanel.Hide();
                MenuButtonPanel.Show();
            }
            else
            {
                ReservationsPressedPanel.Show();
                MenuButtonPanel.Hide();
            }
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            if (ProfilePressedPanel.Visible)
            {
                ProfilePressedPanel.Hide();
                MenuButtonPanel.Show();
            }
            else
            {
                ProfilePressedPanel.Show();
                MenuButtonPanel.Hide();
            }
        }

        private void ProfileButton2_Click(object sender, EventArgs e)
        {
            ProfilePressedPanel.Hide();
            MenuButtonPanel.Show();
            viewProfileControl1.Hide();
            editProfileControl1.Hide();
        }

        private void BackButton5_Click(object sender, EventArgs e)
        {
            ProfilePressedPanel.Hide();
            MenuButtonPanel.Show();
            viewProfileControl1.Hide();
            editProfileControl1.Hide();
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            editProfileControl1.setAuthValue(AuthValue);
            viewProfileControl1.Hide();
            editProfileControl1.Show();
        }

        private void ViewProfileButton_Click(object sender, EventArgs e)
        {
            viewProfileControl1.setAuthValue(AuthValue);
            viewProfileControl1.Show();
            editProfileControl1.Hide();
        }

        private void showMenuControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
