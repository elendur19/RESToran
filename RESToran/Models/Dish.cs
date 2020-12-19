using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESToran.Models
{
    public class Dish
    {

        public long Id { get; set; }

        [ForeignKey("Restaurant_Id")]
        public long RestaurantId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        // TODO lista sastojaka

        public List<ReservationPeriod> ReservationPeriod { get; set; }

    }
}
