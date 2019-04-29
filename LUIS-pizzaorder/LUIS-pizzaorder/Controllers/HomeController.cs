using JSONUtils;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Configuration;
using LUIS_pizzaorder.Models;
using System.Linq;

namespace LUIS_pizzaorder.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> HomeStart(string String)
        {
            
            Query Return = new Query();
            //the entities

            //the intents

            try
            {
                if (String != null)
                {
                    LUIS objLUISResult = await QueryLUIS(String);
                    //if (theIntent.intent == "pizzaOrder")
                    //{
                    //Response.Write("<script>alert('You want to order')</script>");

                    foreach (var item in objLUISResult.entities)
                    {
                        if (item.type == "size") { Return.Size = item.entity; }
                        if (item.type == "topping") { Return.Topping = item.entity; }
                        if (item.type == "topping2") { Return.Topping2 = item.entity; }
                        if (item.type == "topping3") { Return.Topping3 = item.entity; }
                        if (item.type == "builtin.number") { Return.Number = item.entity; }
                    }
                    //return View(Return);
                    //}
                    var theIntent = objLUISResult.topScoringIntent;
                    if (theIntent.intent == null)
                    {
                        Response.Write("<script>alert('error ai')</script>");
                    }
                    if (theIntent.intent == "Order")
                    {
                        //ViewBag.Message = string.Format("Your want to order pizza");
                        return View("~/Views/Home/Index.cshtml");

                    }

                    else if (theIntent.intent == "LogIn")
                    {
                        //ViewBag.Message = string.Format("Your want to Login")
                        return View("~/Views/User/Login.cshtml");
                    }
                    else if (theIntent.intent == "SignUp")
                    {
                        //ViewBag.Message = string.Format("Your want to create an account");
                        return View("~/Views/User/Registration.cshtml");
                    }
                    else if (/*theIntent.intent == "None" ||*/ theIntent.intent == "Greeting")
                    {
                        Response.Write("<script>alert('Please enter what you want to do related to pizza ordering. Thanks!')</script>");
                        //ViewBag.Message = string.Format("Okay... please enter what you want to do related to pizza ordering. Thanks!");

                    }
                    Console.Clear();
                }
                return View(Return);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                return View(Return);
            }

        }

        public async Task<ActionResult> Index(string String)
        {
            Query Return = new Query();
            //the entities

            //the intents

            try
            {
                if (String != null)
                {
                    LUIS objLUISResult = await QueryLUIS(String);
                    //if (theIntent.intent == "pizzaOrder")
                    //{
                    //Response.Write("<script>alert('You want to order')</script>");

                    foreach (var item in objLUISResult.entities)
                    {
                        if (item.type == "size") { Return.Size = item.entity; }
                        if (item.type == "topping") { Return.Topping = item.entity; }
                        if (item.type == "topping2") { Return.Topping2 = item.entity; }
                        if (item.type == "topping3") { Return.Topping3 = item.entity; }
                        if (item.type == "builtin.number") { Return.Number = item.entity; }
                    }
                    //return View(Return);
                    //}
                    var theIntent = objLUISResult.topScoringIntent;
                    if(theIntent.intent==null)
                    {
                        Response.Write("<script>alert('error ai')</script>");
                    }
                    if (theIntent.intent == "Order")
                    {
                        //ViewBag.Message = string.Format("Your want to order pizza");
                        return View("~/Views/Home/Index.cshtml");

                    }

                    else if (theIntent.intent == "LogIn")
                    {
                        //ViewBag.Message = string.Format("Your want to Login")
                        return View("~/Views/User/Login.cshtml");
                    }
                    else if (theIntent.intent == "SignUp")
                    {
                        //ViewBag.Message = string.Format("Your want to create an account");
                        return View("~/Views/User/Registration.cshtml");
                    }
                    else if (/*theIntent.intent == "None" ||*/ theIntent.intent == "Greeting")
                    {
                        Response.Write("<script>alert('Please enter what you want to do related to pizza ordering. Thanks!')</script>");
                        //ViewBag.Message = string.Format("Okay... please enter what you want to do related to pizza ordering. Thanks!");

                    }
                    Console.Clear();
                }
                return View(Return);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                return View(Return);
            }


        }

        // Utility
        private static async Task<LUIS> QueryLUIS(string Query)
        {
            LUIS LUISResult = new LUIS();
            var LUISQuery = Uri.EscapeDataString(Query);
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                // Get key values from the web.config
                string LUIS_Url = WebConfigurationManager.AppSettings["LUIS_Url"];
                string LUIS_Subscription_Key = WebConfigurationManager.AppSettings["LUIS_Subscription_Key"];
                string RequestURI = String.Format("{0}?subscription-key={1}&q={2}",
                    LUIS_Url, LUIS_Subscription_Key, LUISQuery);
                System.Net.Http.HttpResponseMessage msg = await client.GetAsync(RequestURI);
                if (msg.IsSuccessStatusCode)
                {
                    var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                    LUISResult = JsonConvert.DeserializeObject<LUIS>(JsonDataResponse);
                }
            }
            return LUISResult;
        }

        public ActionResult SubmitPizza(string size, string cTopping, string mTopping, string vTopping, string num)
        {
            ViewBag.SizeStatus = true;
            pizza orderedPizza = new pizza();

            string pizzaSize = null;
            Nullable<int> toppingCheese = null;
            Nullable<int> toppingMeat = null;
            Nullable<int> toppingVeg = null;

            switch (size)
            {
                case "Small":
                    pizzaSize = "S";
                    break;
                case "Medium":
                    pizzaSize = "M";
                    break;
                case "Large":
                    pizzaSize = "L";
                    break;
                default:
                    ViewBag.SizeStatus = false;
                    break;
            }

            if (ViewBag.SizeStatus == false)
            {
                Response.Write("<script>alert('A size must be chosen!')</script>");
                return View("Index");
            }
            switch (cTopping)
            {
                case "Blue Cheese":
                    toppingCheese = 1;
                    break;
                case "Feta":
                    toppingCheese = 2;
                    break;
                case "Mozzarella":
                    toppingCheese = 3;
                    break;
                case "Pepper Jack":
                    toppingCheese = 4;
                    break;
            }

            switch (mTopping)
            {
                case "Chicken":
                    toppingMeat = 1;
                    break;
                case "Lamb":
                    toppingMeat = 2;
                    break;
                case "Shrimp":
                    toppingMeat = 3;
                    break;
                case "Steak":
                    toppingMeat = 4;
                    break;
                case "Turkey":
                    toppingMeat = 5;
                    break;
            }

            switch (vTopping)
            {
                case "Mushrooms":
                    toppingVeg = 1;
                    break;
                case "Olives":
                    toppingVeg = 2;
                    break;
                case "Peppers":
                    toppingVeg = 3;
                    break;
                case "Spinach":
                    toppingVeg = 4;
                    break;
            }
            orderedPizza.size = pizzaSize;
            orderedPizza.cheese_topping = toppingCheese;
            orderedPizza.meat_topping = toppingMeat;
            orderedPizza.veg_topping = toppingVeg;
            int number = Int32.Parse(num);
            double total = 0;

            using (PizzaContext dc = new PizzaContext())
            {
                dc.pizzas.Add(orderedPizza);
                dc.SaveChanges();
                var query = dc
                    .sizes
                    .Where(a => a.name == orderedPizza.size)
                    .Select(a => a.price)
                    .SingleOrDefault();
                total += double.Parse(query.ToString());

                if (toppingCheese != null)
                {
                    var tquery = dc
                    .topping_cheese
                    .Where(a => a.t_id == orderedPizza.cheese_topping)
                    .Select(a => a.price)
                    .SingleOrDefault();
                    total += double.Parse(tquery.ToString());
                }

                if (toppingMeat != null)
                {
                    var tquery = dc
                    .topping_meat
                    .Where(a => a.t_id == orderedPizza.meat_topping)
                    .Select(a => a.price)
                    .SingleOrDefault();
                    total += double.Parse(tquery.ToString());
                }

                if (toppingVeg != null)
                {
                    var tquery = dc
                     .topping_veg
                     .Where(a => a.t_id == orderedPizza.veg_topping)
                     .Select(a => a.price)
                     .SingleOrDefault();
                    total += double.Parse(tquery.ToString());
                }

            }

            Session["Pizza"] = orderedPizza.pizza_id.ToString();
            if (Session["UserID"] != null)
            {
                user_order _Order = new user_order();
                
                _Order.user_id = Int32.Parse(Session["UserID"].ToString());
                _Order.pizza_id = orderedPizza.pizza_id;
                _Order.total = (decimal)total;

                using (User_OrderContext db = new User_OrderContext())
                {
                    db.user_order.Add(_Order);
                    db.SaveChanges();
                }
            }

            Session["Total"] = total*number;

            return Json(new { success = true, url=Url.Action("Checkout","Home") },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Checkout()
        {
            return View();
        }

    }
}
