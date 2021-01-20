using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESToran.Models
{
    public class Dish
    {

        public long Id { get; set; }

        [ForeignKey("Restaurant_Id")]
        public long RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }

        public bool HouseSpecial { get; set; }

        // TODO lista sastojaka

        public List<ReservationPeriod> ReservationPeriod { get; set; }

    }
}
