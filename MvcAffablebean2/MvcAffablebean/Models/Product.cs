using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAffablebean.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(160)]
        public string Productname{ get; set; }
        [DisplayName("Category")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
             ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [DisplayName("Product URL")]
        [StringLength(1024)]
        public string ProductUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}