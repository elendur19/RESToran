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
using Newtonsoft.Json;
using RESToran;
using RESToran.PresentationLayer.DataClasses;

namespace RESToran.PresentationLayer.UserControls
{
    public partial class ViewReservationsControl : UserControl
    {

        public ViewReservationsControl()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        string AuthValue;
        List<ReservationPeriod> reservationsData;
        public void setAuthValue(string AuthValue)
        {
            this.AuthValue = AuthValue;
            this.updateValues();
        }

        private void updateValues()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/ReservationPeriod/Restaurant/all");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

                reservationsData = JsonConvert.DeserializeObject<List<ReservationPeriod>>(content);
                ReservationsGrid.DataSource = reservationsData;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred");
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/ReservationPeriod/Restaurant/date/all");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                httpWebRequest.Headers["dateReservation"] = selectedDate;
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                reservationsData = JsonConvert.DeserializeObject<List<ReservationPeriod>>(content);
                ReservationsGrid.DataSource = reservationsData;
            }
            catch (Exception except)
            {
                MessageBox.Show("Error occurred");
            }

        }
    }
}
