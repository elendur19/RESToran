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
    public partial class ShowMenuControl : UserControl
    {

        public ShowMenuControl()
        {
            InitializeComponent();
        }

        string AuthValue;
        List<Dish> result;

        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }

        public class Dish
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool Housespecial { get; set; }
        }

        public void getJsonMenu()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Dish/Restaurant/desktopApp/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            result = JsonConvert.DeserializeObject<List<Dish>>(content);
            MenuGrid.DataSource = result;
        }
    }
}
