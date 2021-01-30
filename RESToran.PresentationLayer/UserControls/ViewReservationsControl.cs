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

namespace RESToran.PresentationLayer.UserControls
{
    public partial class ViewReservationsControl : UserControl
    {

        public class ReservationPeriod
        {
            public long Id { get; set; }
            public long RestaurantId { get; set; }

            public long TableId { get; set; }

            public string TableDescription { get; set; }

            public string Date { get; set; }

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }

        }

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/" + "ReservationPeriod/Restaurant/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            reservationsData = JsonConvert.DeserializeObject<List<ReservationPeriod>>(content);
            ReservationsGrid.DataSource = reservationsData;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/ReservationPeriod/Restaurant/date/all");
            httpWebRequest.Headers["Authorization"] = "Basic " + AuthValue;
            httpWebRequest.Headers["dateReservation"] = selectedDate;
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            reservationsData = JsonConvert.DeserializeObject<List<ReservationPeriod>>(content);
            ReservationsGrid.DataSource = reservationsData;
        }
    }
}
