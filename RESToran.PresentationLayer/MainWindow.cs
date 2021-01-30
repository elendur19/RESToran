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
        string menuValue;
        string AuthValue;
        public MainWindow()
        {
            InitializeComponent();
            MenuPanel.Hide();
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

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (MenuPanel.Visible)
            {
                MenuPanel.Hide();
                MenuButtonPanel.Show();
            }
            else
            {
                MenuPanel.Show();
                MenuButtonPanel.Hide();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FoodPressedPanel.Hide();
            MenuPanel.Show();
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Hide();
        }


        private void FoodButton2_Click(object sender, EventArgs e)
        {
            FoodPressedPanel.Hide();
            MenuPanel.Show();
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Hide();

        }

        private void ShowMenuButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.Hide();
            showMenuControl1.setMenuValue(menuValue);
            showMenuControl1.setAuthValue(AuthValue);
            showMenuControl1.Show();
            editMenuControl1.Hide();

        }

        private void EditMenuButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.Hide();
            showMenuControl1.Hide();
            editMenuControl1.Show();
            editMenuControl1.setMenuValue(menuValue);
            editMenuControl1.setAuthValue(AuthValue);
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            addFoodControler1.setMenuValue(menuValue);
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

        private void FoodPressedPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReservationsPressedPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        // WIP
        private void AppetizerButton_Click(object sender, EventArgs e)
        {
            menuValue = "Appetizer";
            updateFoodPanel();
            MenuPanel.Hide();
            FoodPressedPanel.Show();
        }

        private void DesertButton_Click(object sender, EventArgs e)
        {
            menuValue = "Dessert";
            updateFoodPanel();
            MenuPanel.Hide();
            FoodPressedPanel.Show();
        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            menuValue = "Drink";
            updateFoodPanel();
            MenuPanel.Hide();
            FoodPressedPanel.Show();
        }

        private void MainCourseButton_Click(object sender, EventArgs e)
        {
            menuValue = "Main Course";
            updateFoodPanel();
            MenuPanel.Hide();
            FoodPressedPanel.Show();
        }

        private void SaladButton_Click(object sender, EventArgs e)
        {
            menuValue = "Salad";
            updateFoodPanel();
            MenuPanel.Hide();
            FoodPressedPanel.Show();
        }

        private void BackButton7_Click(object sender, EventArgs e)
        {
            menuValue = "";
            MenuButtonPanel.Show();
            MenuPanel.Hide();
        }

        private void updateFoodPanel()
        {
            FoodButton2.Text = menuValue;
            ShowMenuButton.Text = "Show " + menuValue + "s";
            EditMenuButton.Text = "Edit " + menuValue + "s";
            AddFoodButton.Text = "Add " + menuValue + "s";
        }
    }
}
