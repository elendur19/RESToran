using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESToran.PresentationLayer.DataClasses
{
    public class MainCourse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool HouseSpecial { get; set; }
    }
}
