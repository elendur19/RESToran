﻿namespace RESToran.DataClasses
{
    public class DessertInfo
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool HouseSpecial { get; set; }

        public DessertInfo(string Name, double Price, string Description, bool special)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.HouseSpecial = special;
        }
    }
}
