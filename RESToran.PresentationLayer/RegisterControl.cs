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

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                RegisterWindow windowFields = new RegisterWindow { Name = "ime1", EmailAddress = "email1", HoursOpened = "9:00-18:00", Location = "Croatia", Password = "password1", PhoneNumber = "0009209420" };
                var data = JsonConvert.SerializeObject(windowFields);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await  client.PostAsync("Restoran/create", content);

                MessageBox.Show(response.ToString());
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
                label9.Text = result;
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
                        "\"Name\" : \"CUMA PUMA GUMA\"," +
                        "\"EmailAddress\" : \"cumaguma\"," +
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
                label9.Text = result;
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
