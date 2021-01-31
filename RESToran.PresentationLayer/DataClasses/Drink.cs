using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESToran.PresentationLayer.DataClasses
{
    public class Drink : MainCourse
    {
        public bool AgeRestricted { get; set; }
    }
}
