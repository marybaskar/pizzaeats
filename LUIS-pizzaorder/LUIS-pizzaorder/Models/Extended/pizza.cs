using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LUIS_pizzaorder.Models
{
    [MetadataType(typeof(pizzaMetaData))]
    public class pizzaMetaData
    {
        
        public int pizza_id { get; set; }

        
        public string size { get; set; }

        public Nullable<int> cheese_topping { get; set; }

        public Nullable<int> meat_topping { get; set; }

        public Nullable<int> veg_topping { get; set; }
    }
}