using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "MM/dd/yyyy")]
        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
