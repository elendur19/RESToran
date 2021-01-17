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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Restaurant/create");
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

        private void label2_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Restaurant/create");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";

            string json = "{" +
                        "\"Name\" : \"Rest429\"," +
                        "\"EmailAddress\" : \"rest429@gjg.com\"," +
                        "\"Password\" : \"zgzhzgg\"," +
                        "\"Location\" : \"Ulica kralja Ivana\"," +
                        "\"HoursOpened\": \"09:00-18:00\"," +
                        "\"PhoneNumber\": \"0128181811\"}";
            Console.Write(json);
            httpWebRequest.ContentLength = Encoding.ASCII.GetBytes(json).Length;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Console.Write(json);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resultLabel.Text = result;
            }
            // TODO add registration logic here
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

        private void button2_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Restaurant/create");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";

            string json = "{" +
                        "\"Name\" : \"CUMA PUMA GUMA SUMA\"," +
                        "\"EmailAddress\" : \"cumagumasuma\"," +
                        "\"Password\" : \"zgzhzgg\"," +
                        "\"Location\" : \"Ulica kralja Ivana\"," +
                        "\"HoursOpened\": \"09:00-18:00\"," +
                        "\"PhoneNumber\": \"0128181811\"}";
            Console.Write(json);
            httpWebRequest.ContentLength = Encoding.ASCII.GetBytes(json).Length;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Console.Write(json);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resultLabel.Text = result;
            }
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
