namespace RESToran.DataClasses
{
    public class SaladInfo
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool HouseSpecial { get; set; }

        public string Topping { get; set; }

        public SaladInfo(string Name, double Price, string Description, bool special, string topping)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.HouseSpecial = special;
            this.Topping = topping;
        }
    }
}
