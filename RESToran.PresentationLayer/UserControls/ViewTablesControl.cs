using Newtonsoft.Json;
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
    public partial class ViewTablesControl : UserControl
    {
        public ViewTablesControl()
        {
            InitializeComponent();
        }

        string AuthValue;
        List<Rest_Table> result;

        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }

        public void getJsonMenu()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Table/Restaurant/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            result = JsonConvert.DeserializeObject<List<Rest_Table>>(content);
            TablesGrid.DataSource = result;
        }
    }
}
