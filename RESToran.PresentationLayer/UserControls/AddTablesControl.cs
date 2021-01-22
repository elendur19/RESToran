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
    public partial class AddTablesControl : UserControl
    {
        public AddTablesControl()
        {
            InitializeComponent();
        }
        public class Table
        {
            public string Description { get; set; }

            public double NumberOfSeats { get; set; }
        }

        string AuthValue;
        Table table;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Table/Restaurant/create");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            table = new Table();
            table.Description = DescriptionTextBox.Text;
            try
            {
                table.NumberOfSeats = Convert.ToInt16(NumberOfSeatsBox.Text);
                if(table.NumberOfSeats == 0)
                {
                    throw new ArgumentNullException("Invalid value");
                }
            }
            catch (Exception error)
            {
                ResultLabel.Text = "Number of seats should be integer";
                return;
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
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
