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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Enter start time.")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Enter end time.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

    }
}
