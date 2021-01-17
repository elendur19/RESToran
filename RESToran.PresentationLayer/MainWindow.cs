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
        public MainWindow()
        {
            InitializeComponent();
            FoodPressedPanel.Hide();
            ReservationsPressedPanel.Hide();
            TablesPressedPanel.Hide();
            ProfilePressedPanel.Hide();
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
        }


        private void FoodButton2_Click(object sender, EventArgs e)
        {
            FoodPressedPanel.Hide();
            MenuButtonPanel.Show();
        }

        private void ShowMenuButton_Click(object sender, EventArgs e)
        {

        }

        private void EditMenuButton_Click(object sender, EventArgs e)
        {

        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {

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
        }

        private void ViewTablesButton_Click(object sender, EventArgs e)
        {

        }

        private void ManageTablesButton_Click(object sender, EventArgs e)
        {

        }

        private void AddTablesButton_Click(object sender, EventArgs e)
        {

        }

        private void BackTablesButton_Click(object sender, EventArgs e)
        {
            TablesPressedPanel.Hide();
            MenuButtonPanel.Show();
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
        }

        private void BackButton5_Click(object sender, EventArgs e)
        {
            ProfilePressedPanel.Hide();
            MenuButtonPanel.Show();
        }
    }
}
