using System;

namespace RESToran.DataClasses
{
    public class ReservationPeriodInfo
    {
        public long Id { get; set; }

       
        public long RestaurantId { get; set; }

       
        public long TableId { get; set; }

        public string TableDescription { get; set; }

        public string Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ReservationPeriodInfo(long Id, long RestaurantId, long TableId, string TableDescription, string Date, DateTime StartTime, DateTime EndTime)
        {
            this.Id = Id;
            this.RestaurantId = RestaurantId;
            this.TableId = TableId;
            this.TableDescription = TableDescription;
            this.Date = Date;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
