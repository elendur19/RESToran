using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESToran.Models
{
    public class Salad : Dish
    {
        public string Topping { get; set; }
    }
}
