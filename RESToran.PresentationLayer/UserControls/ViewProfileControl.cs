using Newtonsoft.Json.Linq;
using RESToran.PresentationLayer.DataClasses;
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Restaurant/info");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            string json = @"{""restaurant"":" + content + "}";
            Restaurant restaurant = new Restaurant(json);
            NameLabel.Text = "Name: " + restaurant.name;
            EmailAddressLabel.Text = "Email Address: " + restaurant.emailAddress;
            LocationLabel.Text = "Location: " + restaurant.location;
            PhoneNumberLabel.Text = "Phone Number: " + restaurant.phoneNumber;
            HoursOpenLabel.Text = "Hours Opened: " + restaurant.hoursOpened;
        }
    }
}
