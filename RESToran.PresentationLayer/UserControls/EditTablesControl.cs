using Newtonsoft.Json;
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
    public partial class EditTablesControl : UserControl
    {
        public EditTablesControl()
        {
            InitializeComponent();
            EditTablePanel.Hide();
        }

        string AuthValue;
        List<Table> result;
        Table old;

        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }

        public class Table
        {
            public string Description { get; set; }

            public string RestName_Number { get; set; }

            public double NumberOfSeats { get; set; }
        }

        public void getJsonMenu()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Table/Restaurant/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            result = JsonConvert.DeserializeObject<List<Table>>(content);
            TablesGrid.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EditTablePanel.Visible)
            {
                Table table = new Table();
                try
                {
                    table.NumberOfSeats = Convert.ToInt16(NumberOfSeatsBox.Text);
                    if (table.NumberOfSeats == 0)
                    {
                        throw new ArgumentNullException("Invalid value");
                    }
                }
                catch (Exception error)
                {
                    return;
                }
                table.Description = DescriptionTextBox.Text;
                table.RestName_Number = old.RestName_Number;
                string json = JsonConvert.SerializeObject(table);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Table/Restaurant/edit");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                httpWebRequest.Headers["tableNumber"] = table.RestName_Number.Split(' ')[1];
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Method = "POST";
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
                    }
                }
                catch (System.Net.WebException error)
                {
                    MessageBox.Show(error.ToString());
                }

                EditTablePanel.Hide();
                TablesGrid.Show();
                button1.Text = "Choose";
                getJsonMenu();
            }
            else
            {
                DataGridViewRow row = TablesGrid.CurrentRow;
                Table table = new Table();
                table.Description = (string)row.Cells["Description"].Value;
                table.RestName_Number = (string)row.Cells["RestName_Number"].Value;
                table.NumberOfSeats = (double)row.Cells["NumberOfSeats"].Value;
                old = table;
                EditTablePanel.Show();
                TablesGrid.Hide();
                button1.Text = "Submit";
                DescriptionTextBox.Text = table.Description;
                NumberOfSeatsBox.Text = table.NumberOfSeats.ToString();
            }
        }
    }
}
