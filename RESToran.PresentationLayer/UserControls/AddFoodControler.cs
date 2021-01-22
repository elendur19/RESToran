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
            /*public MainCourse(string json)
            {
                JObject jObject = JObject.Parse(json);
                JToken jDish = jObject["MainCourse"];
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
        MainCourse mainCourse;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
        }

        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/MainCourse/Restaurant/create");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            mainCourse = new MainCourse();
            mainCourse.Name = NameBox.Text;
            mainCourse.Price = Convert.ToDouble(PriceBox.Text);
            mainCourse.Description = DescriptionTextBox.Text;
            mainCourse.Housespecial = HouseSpecialCheckBox.Checked;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(mainCourse);
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
