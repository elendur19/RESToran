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

        [Required(ErrorMessage ="Enter the date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Enter the time.")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Enter the time.")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

    }
}
