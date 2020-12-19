using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class Restaurant
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string HoursOpened { get; set; }

        public double Rating { get; set; }

        public List<Table> Tables { get; set; }

        public List<Dish> Dishes { get; set; }
    }
}
