﻿using Newtonsoft.Json;
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

        public void getJsonMenu()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/" + menuValue + "/Restaurant/desktopApp/all");
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
            catch (Exception except)
            {
                MessageBox.Show("Error occurred");
            }
        }
    }
}
