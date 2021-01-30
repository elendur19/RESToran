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
        List<MainCourse> resultCourse;
        List<Salad> resultSalad;
        List<Drink> resultDrink;
        string menuValue;

        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.getJsonMenu();
        }
        public void setMenuValue(string menuValue)
        {
            this.menuValue = menuValue;
            label1.Text = "Add " + menuValue + " to Menu";
        }

        public class MainCourse
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public bool Housespecial { get; set; }
        }
        public class Salad
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Description { get; set; }

            public bool HouseSpecial { get; set; }

            public string Topping { get; set; }
        }

        public class Drink
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Description { get; set; }

            public bool HouseSpecial { get; set; }

            public bool AgeRestricted { get; set; }
        }

        public void getJsonMenu()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/"+menuValue+"/Restaurant/desktopApp/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (menuValue != "Salad" && menuValue != "Drink")
            {
                resultCourse = JsonConvert.DeserializeObject<List<MainCourse>>(content);
                MenuGrid.DataSource = resultCourse;
            }
            else if (menuValue == "Salad")
            {
                resultSalad = JsonConvert.DeserializeObject<List<Salad>>(content);
                MenuGrid.DataSource = resultSalad;
            }
            else if (menuValue == "Drink")
            {
                resultDrink = JsonConvert.DeserializeObject<List<Drink>>(content);
                MenuGrid.DataSource = resultDrink;
            }

        }
    }
}
