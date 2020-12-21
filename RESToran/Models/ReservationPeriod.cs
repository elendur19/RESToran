using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class ReservationPeriod
    {
        public long Id { get; set; }
        [ForeignKey("Restaurant_id")]
        public long RestaurantId { get; set; }

        [ForeignKey("Table_id")]
        public long TableId { get; set; }

        public string TableDescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
