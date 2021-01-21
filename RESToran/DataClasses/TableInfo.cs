namespace RESToran.DataClasses
{
    public class TableInfo
    {
        public string Description { get; set; }

        public string RestName_Number { get; set; }

        public double NumberOfSeats { get; set; }

        public TableInfo(string tableDescription, string tableRestName_Number, double tableNumberOfSeats)
        {
            Description = tableDescription;
            RestName_Number = tableRestName_Number;
            NumberOfSeats = tableNumberOfSeats;
        }
        
       
    }
}
