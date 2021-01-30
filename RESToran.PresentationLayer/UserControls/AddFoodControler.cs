using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace RESToran.PresentationLayer.UserControls
{
    public partial class AddFoodControler : UserControl
    {
        public AddFoodControler()
        {
            InitializeComponent();
        }
        public class MainCourse
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool Housespecial { get; set; }
        }

        public class Salad
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Description { get; set; }

            public bool HouseSpecial { get; set; }

            public string Topping { get; set; }
        }

        public class Drink
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Description { get; set; }

            public bool HouseSpecial { get; set; }

            public bool AgeRestricted { get; set; }
        }

        Drink drink;
        Salad salad;
        string AuthValue;
        string menuValue;
        MainCourse mainCourse;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
        }
        
        public void setMenuValue(string menuValue)
        {
            this.menuValue = menuValue;
            toppingBox.Hide();
            changingLabel.Hide();
            ageRestrictedCheckbox.Hide();
            label1.Text = "Add " + menuValue + " to Menu";
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
        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/"+menuValue+"/Restaurant/create");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            string json ="";
            if (menuValue!="Salad" && menuValue != "Drink")
            {
                mainCourse = new MainCourse();
                mainCourse.Name = NameBox.Text;
                mainCourse.Price = Convert.ToDouble(PriceBox.Text);
                mainCourse.Description = DescriptionTextBox.Text;
                mainCourse.Housespecial = HouseSpecialCheckBox.Checked;
                json = Newtonsoft.Json.JsonConvert.SerializeObject(mainCourse);
            }else if(menuValue== "Salad")
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
