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
    public partial class ViewProfileControl : UserControl
    {
        public class Restaurant
        {
            public Restaurant(string json)
            {
                JObject jObject = JObject.Parse(json);
                JToken jRestaurant = jObject["restaurant"];
                Name = (string)jRestaurant["name"];
                EmailAddress = (string)jRestaurant["emailAddress"];
                Location = (string)jRestaurant["location"];
                PhoneNumber = (string)jRestaurant["phoneNumber"];
                HoursOpened = (string)jRestaurant["hoursOpened"];
            }

            public string Name { get; set; }
            public string EmailAddress { get; set; }
            public string Location { get; set; }
            public string PhoneNumber { get; set; }
            public string HoursOpened { get; set; }
        }

        string AuthValue;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.updateValues();
        }

        public ViewProfileControl()
        {
            InitializeComponent();
        }

        public void updateValues()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Restaurant/info");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            string json = @"{""restaurant"":" + content + "}";
            Restaurant restaurant = new Restaurant(json);
            NameLabel.Text = "Name: " + restaurant.Name;
            EmailAddressLabel.Text = "Email Address: " + restaurant.EmailAddress;
            LocationLabel.Text = "Location: " + restaurant.Location;
            PhoneNumberLabel.Text = "Phone Number: " + restaurant.PhoneNumber;
            HoursOpenLabel.Text = "Hours Opened: " + restaurant.HoursOpened;
        }
    }
}
