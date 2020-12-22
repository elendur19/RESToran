using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESToran.Models
{
    public class Table
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Restaurant_Id")]
        public long RestaurantId { get; set; }

        public string Description { get; set; }
        
        public string RestName_Number { get; set; }

        public double NumberOfSeats{ get; set; }

        public List<ReservationPeriod> ReservationPeriod { get; set; }
    }
}
