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
    public partial class EditProfileControl : UserControl
    {
        public EditProfileControl()
        {
            InitializeComponent();
        }

        public class Restaurant
        {
            public Restaurant(string json)
            {
                JObject jObject = JObject.Parse(json);
                JToken jRestaurant = jObject["restaurant"];
                name = (string)jRestaurant["name"];
                emailAddress = (string)jRestaurant["emailAddress"];
                location = (string)jRestaurant["location"];
                phoneNumber = (string)jRestaurant["phoneNumber"];
                hoursOpened = (string)jRestaurant["hoursOpened"];
            }

            public string name { get; set; }
            public string emailAddress { get; set; }
            public string location { get; set; }
            public string phoneNumber { get; set; }
            public string hoursOpened { get; set; }
        }

        string AuthValue;
        Restaurant restaurant;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            resultLabel.Text = "";
            this.updateValues();
        }

        public void updateValues()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Restaurant/info");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            string json = @"{""restaurant"":" + content + "}";
            restaurant = new Restaurant(json);
            NameBox.Text = restaurant.name;
            EmailBox.Text = restaurant.emailAddress;
            LocationBox.Text = restaurant.location;
            PhoneBox.Text = restaurant.phoneNumber;
            HoursBox.Text = restaurant.hoursOpened;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Restaurant/edit");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            restaurant.name = NameBox.Text;
            restaurant.emailAddress = EmailBox.Text;
            restaurant.location = LocationBox.Text;
            restaurant.phoneNumber = PhoneBox.Text;
            restaurant.hoursOpened = HoursBox.Text;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(restaurant);
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
                    resultLabel.Text = "SUCCESS!";
                }
            }
            catch (System.Net.WebException error)
            {
                resultLabel.Text = "Failed!";
            }
        }
    }
}
