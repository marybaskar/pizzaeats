using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LUIS_pizzaorder.Models
{
    [MetadataType(typeof(user_orderMetaData))]
    public class user_orderMetaData
    {

        public int user_id { get; set; }

        public int pizza_id { get; set; }

        public decimal total { get; set; }
    }
}