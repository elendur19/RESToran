using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESToran.PresentationLayer.UserControls
{
    public partial class EditMenuControl : UserControl
    {

        public EditMenuControl()
        {
            InitializeComponent();
            panel1.Hide();
        }

        string AuthValue;
        List<MainCourse> resultCourse;
        MainCourse old;
        Drink drink;
        Salad salad;
        List<Salad> resultSalad;
        List<Drink> resultDrink;
        string menuValue;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }
        public void setMenuValue(string menuValue)
        {
            this.menuValue = menuValue;
            toppingBox.Hide();
            changingLabel.Hide();
            ageRestrictedCheckbox.Hide();
            label1.Text = "Change " + menuValue + " in Menu";
            if (menuValue == "Salad")
            {
                changingLabel.Text = "Topping:";
                changingLabel.Show();
                toppingBox.Show();
            }
            if (menuValue == "Drink")
            {
                changingLabel.Text = "Age restricted:";
                changingLabel.Show();
                ageRestrictedCheckbox.Show();
            }
        }

        public class MainCourse
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool HouseSpecial { get; set; }
        }
        public class Salad : MainCourse
        {
            public string Topping { get; set; }
        }

        public class Drink :MainCourse
        {
            public bool AgeRestricted { get; set; }
        }

        public void getJsonMenu()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/" +menuValue+"/Restaurant/desktopApp/all");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (menuValue != "Salad" && menuValue != "Drink")
                {
                    resultCourse = JsonConvert.DeserializeObject<List<MainCourse>>(content);
                    MenuGrid.DataSource = resultCourse;
                }
                else if (menuValue == "Salad")
                {
                    resultSalad = JsonConvert.DeserializeObject<List<Salad>>(content);
                    MenuGrid.DataSource = resultSalad;
                }
                else if (menuValue == "Drink")
                {
                    resultDrink = JsonConvert.DeserializeObject<List<Drink>>(content);
                    MenuGrid.DataSource = resultDrink;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("There is nothing to show. Please add food.");
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                string json = "";
                if (menuValue != "Salad" && menuValue != "Drink")
                {
                    MainCourse mainCourse = new MainCourse();
                    mainCourse = new MainCourse();
                    mainCourse.Name = NameBox.Text;
                    mainCourse.Price = Convert.ToDouble(PriceBox.Text);
                    mainCourse.Description = DescriptionTextBox.Text;
                    mainCourse.HouseSpecial = HouseSpecialCheckBox.Checked;
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(mainCourse);
                }
                else if (menuValue == "Salad")
                {
                    salad = new Salad();
                    salad.Name = NameBox.Text;
                    salad.Price = Convert.ToDouble(PriceBox.Text);
                    salad.Description = DescriptionTextBox.Text;
                    salad.HouseSpecial = HouseSpecialCheckBox.Checked;
                    salad.Topping = toppingBox.Text;
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(salad);
                }
                else if (menuValue == "Drink")
                {
                    drink = new Drink();
                    drink.Name = NameBox.Text;
                    drink.Price = Convert.ToDouble(PriceBox.Text);
                    drink.Description = DescriptionTextBox.Text;
                    drink.HouseSpecial = HouseSpecialCheckBox.Checked;
                    drink.AgeRestricted = ageRestrictedCheckbox.Checked;
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(drink);
                }

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/" +menuValue+"/Restaurant/edit");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                httpWebRequest.Headers[char.ToLower(menuValue[0])+menuValue.Substring(1)+"Name"] = old.Name;
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = Encoding.ASCII.GetBytes(json).Length;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode.ToString() == "OK")
                    {
                    }
                }
                catch (System.Net.WebException error)
                {
                    MessageBox.Show(error.ToString());
                }

                panel1.Hide();
                MenuGrid.Show();
                button1.Text = "Choose";
                getJsonMenu();
            }
            else
            {
                DataGridViewRow row = MenuGrid.CurrentRow;
                if (menuValue != "Salad" && menuValue != "Drink")
                {
                    MainCourse mainCourse = new MainCourse();
                    mainCourse.Name = (string)row.Cells["Name"].Value;
                    mainCourse.Price = (double)row.Cells["Price"].Value;
                    mainCourse.Description = (string)row.Cells["Description"].Value;
                    mainCourse.HouseSpecial = (bool)row.Cells["Housespecial"].Value;
                    old = mainCourse;
                    NameBox.Text = mainCourse.Name;
                    PriceBox.Text = (string)mainCourse.Price.ToString();
                    HouseSpecialCheckBox.Checked = mainCourse.HouseSpecial;
                    DescriptionTextBox.Text = mainCourse.Description;
                }
                else if (menuValue == "Salad")
                {
                    Salad mainCourse = new Salad();
                    mainCourse.Name = (string)row.Cells["Name"].Value;
                    mainCourse.Price = (double)row.Cells["Price"].Value;
                    mainCourse.Description = (string)row.Cells["Description"].Value;
                    mainCourse.HouseSpecial = (bool)row.Cells["Housespecial"].Value;
                    mainCourse.Topping = (string)row.Cells["Topping"].Value;
                    old = mainCourse;
                    NameBox.Text = mainCourse.Name;
                    PriceBox.Text = (string)mainCourse.Price.ToString();
                    HouseSpecialCheckBox.Checked = mainCourse.HouseSpecial;
                    DescriptionTextBox.Text = mainCourse.Description;
                    toppingBox.Text = mainCourse.Topping;
                }
                else if (menuValue == "Drink")
                {
                    Drink mainCourse = new Drink();
                    mainCourse.Name = (string)row.Cells["Name"].Value;
                    mainCourse.Price = (double)row.Cells["Price"].Value;
                    mainCourse.Description = (string)row.Cells["Description"].Value;
                    mainCourse.HouseSpecial = (bool)row.Cells["Housespecial"].Value;
                    mainCourse.AgeRestricted = (bool)row.Cells["AgeRestricted"].Value;
                    old = mainCourse;
                    NameBox.Text = mainCourse.Name;
                    PriceBox.Text = (string)mainCourse.Price.ToString();
                    HouseSpecialCheckBox.Checked = mainCourse.HouseSpecial;
                    DescriptionTextBox.Text = mainCourse.Description;
                    ageRestrictedCheckbox.Checked = mainCourse.AgeRestricted;
                }

                panel1.Show();
                MenuGrid.Hide();
                button1.Text = "Submit";

            }
        }
    }
}
