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
    public partial class ViewTablesControl : UserControl
    {
        public ViewTablesControl()
        {
            InitializeComponent();
        }

        string AuthValue;
        List<Table> result;

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Table/Restaurant/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            result = JsonConvert.DeserializeObject<List<Table>>(content);
            TablesGrid.DataSource = result;
        }
    }
}
