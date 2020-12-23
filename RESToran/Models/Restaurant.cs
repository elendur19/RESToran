using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class Restaurant
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string HoursOpened { get; set; }

        public double Rating { get; set; }

        public List<Table> Tables { get; set; }

        public List<Dish> Dishes { get; set; }
    }
}
