using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class Table
    {
        public long Id { get; set; }

        [ForeignKey("Restaurant_Id")]
        public long RestaurantId { get; set; }

        public string Location { get; set; }

        public double NumberOfSeats{ get; set; }

        public List<ReservationPeriod> ReservationPeriod { get; set; }
    }
}
