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
        List<Dish> result;
        Dish old;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }

        public class Dish
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool Housespecial { get; set; }
        }

        public void getJsonMenu()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Dish/Restaurant/desktopApp/all");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Dish>>(content);
                MenuGrid.DataSource = result;
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
                Dish dish = new Dish();
                dish.Name = NameBox.Text;
                dish.Price = Convert.ToDouble(PriceBox.Text);
                dish.Housespecial = HouseSpecialCheckBox.Checked;
                dish.Description = DescriptionTextBox.Text;
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dish);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Dish/Restaurant/edit");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                httpWebRequest.Headers["dishName"] = old.Name;
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
                Dish dish = new Dish();
                dish.Name = (string)row.Cells["Name"].Value;
                dish.Price = (double)row.Cells["Price"].Value;
                dish.Description = (string)row.Cells["Description"].Value;
                dish.Housespecial = (bool)row.Cells["Housespecial"].Value;
                old = dish;
                panel1.Show();
                MenuGrid.Hide();
                button1.Text = "Submit";
                NameBox.Text = dish.Name;
                PriceBox.Text = (string) dish.Price.ToString();
                HouseSpecialCheckBox.Checked = dish.Housespecial;
                DescriptionTextBox.Text = dish.Description;
            }
        }
    }
}
