using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JSONUtils
{

    public class TopScoringIntent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
    }

    public class LUIS
    {
        public string query { get; set; }
        public TopScoringIntent topScoringIntent { get; set; }
        public IList<Intent> intents { get; set; }
        public IList<Entity> entities { get; set; }
    }
    
    public class Query
    {
        [Required(ErrorMessage = "Pizza Size Required")]
        public string Size { get; set; }

        [Display(Name ="Cheese Topping")]
        public string Topping { get; set; }

        [Display(Name = "Meat Topping")]
        public string Topping2 { get; set; }

        [Display(Name = "Vegetable Topping")]
        public string Topping3 { get; set; }

        public string Number { get; set; }

        public bool NoSize
        {
            get { return string.IsNullOrWhiteSpace(Size) ; }
        }
        public bool NoTopping 
        {
            get { return (string.IsNullOrWhiteSpace(Topping) && string.IsNullOrWhiteSpace(Topping2) && string.IsNullOrWhiteSpace(Topping3)); }
        }
        public bool NoNumber
        {
            get { return string.IsNullOrWhiteSpace(Number); }
        }
    }

    

}
//namespace LUIS_pizzaorder.Models
//{
//public class LUIS
//{
// }
//}