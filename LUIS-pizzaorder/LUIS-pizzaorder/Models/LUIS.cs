using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        public string Size { get; set; }
        public string Topping { get; set; }

        public string Number { get; set; }
        
        //public string Greeting { get; set; }
    }



}
//namespace LUIS_pizzaorder.Models
//{
//public class LUIS
//{
// }
//}