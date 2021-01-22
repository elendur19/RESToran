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
        List<MainCourse> result;
        MainCourse old;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }

        public class MainCourse
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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/MainCourse/Restaurant/desktopApp/all");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                result = JsonConvert.DeserializeObject<List<MainCourse>>(content);
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
                MainCourse MainCourse = new MainCourse();
                MainCourse.Name = NameBox.Text;
                MainCourse.Price = Convert.ToDouble(PriceBox.Text);
                MainCourse.Housespecial = HouseSpecialCheckBox.Checked;
                MainCourse.Description = DescriptionTextBox.Text;
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(MainCourse);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/MainCourse/Restaurant/edit");
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
                MainCourse MainCourse = new MainCourse();
                MainCourse.Name = (string)row.Cells["Name"].Value;
                MainCourse.Price = (double)row.Cells["Price"].Value;
                MainCourse.Description = (string)row.Cells["Description"].Value;
                MainCourse.Housespecial = (bool)row.Cells["Housespecial"].Value;
                old = MainCourse;
                panel1.Show();
                MenuGrid.Hide();
                button1.Text = "Submit";
                NameBox.Text = MainCourse.Name;
                PriceBox.Text = (string) MainCourse.Price.ToString();
                HouseSpecialCheckBox.Checked = MainCourse.Housespecial;
                DescriptionTextBox.Text = MainCourse.Description;
            }
        }
    }
}
