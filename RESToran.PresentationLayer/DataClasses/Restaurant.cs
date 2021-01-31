using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESToran.PresentationLayer.DataClasses
{
    public class Restaurant
    {
        public Restaurant(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jRestaurant = jObject["restaurant"];
            name = (string)jRestaurant["name"];
            emailAddress = (string)jRestaurant["emailAddress"];
            location = (string)jRestaurant["location"];
            phoneNumber = (string)jRestaurant["phoneNumber"];
            hoursOpened = (string)jRestaurant["hoursOpened"];
        }

        public string name { get; set; }
        public string emailAddress { get; set; }
        public string location { get; set; }
        public string phoneNumber { get; set; }
        public string hoursOpened { get; set; }
    }
}
