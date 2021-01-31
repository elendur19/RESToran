using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESToran.PresentationLayer.DataClasses
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
}
