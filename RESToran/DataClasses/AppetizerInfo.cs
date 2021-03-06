﻿namespace RESToran.DataClasses
{
    public class AppetizerInfo
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool HouseSpecial { get; set; }

        public AppetizerInfo(string Name, double Price, string Description, bool special)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.HouseSpecial = special;
        }
    }
}
