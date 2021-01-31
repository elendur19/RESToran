using RESToran.PresentationLayer.DataClasses;
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

        Drink drink;
        Salad salad;
        string AuthValue;
        string menuValue;
        MainCourse mainCourse;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            ResultLabel.Text = "";
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/" +menuValue+"/Restaurant/create");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            string json ="";
            if (menuValue!="Salad" && menuValue != "Drink")
            {
                mainCourse = new MainCourse();
                mainCourse.Name = NameBox.Text;
                try
                {
                    mainCourse.Price = Convert.ToDouble(PriceBox.Text);
                    if (mainCourse.Price == 0)
                    {
                        throw new ArgumentNullException("Invalid value");
                    }
                }
                catch (Exception error)
                {
                    ResultLabel.Text = "Price should be number.";
                    return;
                }
                mainCourse.Description = DescriptionTextBox.Text;
                mainCourse.HouseSpecial = HouseSpecialCheckBox.Checked;
                json = Newtonsoft.Json.JsonConvert.SerializeObject(mainCourse);
            }else if(menuValue== "Salad")
            {
                salad = new Salad();
                salad.Name = NameBox.Text;
                try
                {
                    salad.Price = Convert.ToDouble(PriceBox.Text);
                    if (salad.Price == 0)
                    {
                        throw new ArgumentNullException("Invalid value");
                    }
                }
                catch (Exception error)
                {
                    ResultLabel.Text = "Price should be number.";
                    return;
                }
                salad.Description = DescriptionTextBox.Text;
                salad.HouseSpecial = HouseSpecialCheckBox.Checked;
                salad.Topping = toppingBox.Text;
                json = Newtonsoft.Json.JsonConvert.SerializeObject(salad);
            }
            else if (menuValue == "Drink")
            {
                drink = new Drink();
                drink.Name = NameBox.Text;
                try
                {
                    drink.Price = Convert.ToDouble(PriceBox.Text);
                    if (drink.Price == 0)
                    {
                        throw new ArgumentNullException("Invalid value");
                    }
                }
                catch (Exception error)
                {
                    ResultLabel.Text = "Price should be number.";
                    return;
                }
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
                    clearBoxes();
                }
            }
            catch (System.Net.WebException error)
            {
                ResultLabel.Text = "Failed!";
            }
        }

        private void clearBoxes()
        {
            NameBox.Text = "";
            PriceBox.Text = "";
            DescriptionTextBox.Text = "";
            HouseSpecialCheckBox.Checked = false;
            ageRestrictedCheckbox.Checked = false;
            toppingBox.Text = "";
        }
    }
}
