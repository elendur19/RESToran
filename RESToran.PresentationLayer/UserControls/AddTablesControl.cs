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
    public partial class AddTablesControl : UserControl
    {
        public AddTablesControl()
        {
            InitializeComponent();
        }

        string AuthValue;
        Table table;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            ResultLabel.Text = "";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Table/Restaurant/create");
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

            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    ResultLabel.Text = "SUCCESS!";
                    clearData();
                }
            }
            catch (System.Net.WebException error)
            {
                MessageBox.Show(error.ToString());
                ResultLabel.Text = "Failed!";
            }
        }

        private void clearData()
        {
            NumberOfSeatsBox.Text = "";
            DescriptionTextBox.Text = "";
        }
    }
}
