using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Models
{
    public class ReservationPeriod
    {
        public long Id { get; set; }

        [ForeignKey("Table_Id")]
        public long TableId { get; set; }


        public DateTime Datum { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

    }
}
