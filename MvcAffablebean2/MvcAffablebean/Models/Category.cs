using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAffablebean.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> products { get; set; }
    }
}