using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class ManageReservationsControl : UserControl
    {

        public ManageReservationsControl()
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
            catch (Exception except)
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

        private void CancelReservationButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/ReservationPeriod/Restaurant/delete");
                httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
                DataGridViewRow row = ReservationsGrid.CurrentRow;
                httpWebRequest.Method = "DELETE";
                httpWebRequest.Headers["tableId"] = (string)row.Cells["TableId"].Value.ToString();
                httpWebRequest.Headers["startTime"] = parseHours((string)row.Cells["StartTime"].Value.ToString());
                httpWebRequest.Headers["endTime"] = parseHours((string)row.Cells["EndTime"].Value.ToString());
                httpWebRequest.Headers["dateReservation"] = (string)row.Cells["Date"].Value.ToString();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                updateValues();
            }
            catch (Exception except)
            {
                MessageBox.Show("Error occurred");
            }
        }

        private string parseHours(string time)
        {
            DateTime time2 = DateTime.Parse(time);
            string timeString = time2.ToString("HH:mm");
            return timeString;
        }
    }
}
