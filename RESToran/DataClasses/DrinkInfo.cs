using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.DataClasses
{
    public class DrinkInfo
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool HouseSpecial { get; set; }

        public bool AgeRestricted { get; set; }

        public DrinkInfo(string Name, double Price, string Description, bool special, bool ageRestricted)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.HouseSpecial = special;
            this.AgeRestricted = ageRestricted;
        }
    }
}
