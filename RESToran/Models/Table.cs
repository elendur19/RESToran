using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class Table
    {
        [ForeignKey("Restaurant_Id")]
        public long RestaurantId { get; set; }

        public long Id { get; set; }

        public string Location { get; set; }

        public double Rating { get; set; }

        public ICollection<ReservationPeriod> ReservationPeriod { get; set; }
    }
}
