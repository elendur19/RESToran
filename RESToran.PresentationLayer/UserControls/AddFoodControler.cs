using Newtonsoft.Json.Linq;
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
    public partial class AddFoodControler : UserControl
    {
        public AddFoodControler()
        {
            InitializeComponent();
        }
        public class Dish
        {
            /*public Dish(string json)
            {
                JObject jObject = JObject.Parse(json);
                JToken jDish = jObject["dish"];
                Name = (string)jDish["Name"];
                Price = (double)jDish["Price"];
                Description = (string)jDish["Description"];
                Housespecial = (bool)jDish["Housespecial"];
            }*/

            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool Housespecial { get; set; }
        }

        string AuthValue;
        Dish dish;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
        }

        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Dish/Restaurant/create");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            dish = new Dish();
            dish.Name = NameBox.Text;
            dish.Price = Convert.ToDouble(PriceBox.Text);
            dish.Description = DescriptionTextBox.Text;
            dish.Housespecial = HouseSpecialCheckBox.Checked;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dish);
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
                    ResultLabel.Text = "SUCCESS!";
                }
            }
            catch (System.Net.WebException error)
            {
                MessageBox.Show(error.ToString());
                ResultLabel.Text = "Failed!";
            }
        }
    }
}
