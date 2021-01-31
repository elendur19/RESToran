using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RESToran.PresentationLayer
{
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Restaurant/create");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";

            string json = "{" +
                        "\"Name\" : \""+ NameBox.Text +"\"," +
                        "\"EmailAddress\" : \"" + EmailBox.Text + "\"," +
                        "\"Password\" : \""+ PasswordBox1.Text +  "\"," +
                        "\"Location\" : \"" + LocationBox.Text +"\"," +
                        "\"HoursOpened\": \"" + OpenedBox.Text +"\"," +
                        "\"PhoneNumber\": \"" + PhoneBox.Text +"\"}";
            httpWebRequest.ContentLength = Encoding.ASCII.GetBytes(json).Length;
            if (PasswordBox1.Text != PasswordBox2.Text)
            {
                resultLabel.Text = "Passwords not matching!";
            }
            else
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {


                    streamWriter.Write(json);
                }
                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode.ToString() == "OK")
                    {
                        resultLabel.Text = "SUCCESS";
                    }
                }
                catch (System.Net.WebException error)
                {
                    resultLabel.Text = "User already exists!";
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {

        }
    }

    public class RegisterWindow
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string HoursOpened { get; set; }
        public string PhoneNumber { get; set; }

    }
}
