using JSONUtils;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Configuration;
using LUIS_pizzaorder.Models;

namespace LUIS_pizzaorder.Controllers
{
    public class HomeController : Controller
    {
        #region public async Task<ActionResult> Index(string String)
        [HttpGet]
        public ActionResult Size()
        {
            return View("Size");
        }
        [HttpGet]
        public ActionResult Topping()
        {
            return View("Topping");
        }

        public async Task<ActionResult> Index(string String)
        {
            Query Return = new Query();
            try
            {
                if (String != null)
                {
                    LUIS objLUISResult = await QueryLUIS(String);

                    foreach (var item in objLUISResult.entities)
                    {

                        if (item.type == "size")
                        {
                            Return.Size = item.entity;
                        }

                        if (item.type == "topping")
                        {
                            Return.Topping = item.entity;
                        }

                        if (item.type == "topping2")
                        {
                            Return.Topping2 = item.entity;
                        }
                        if (item.type == "topping3")
                        {
                            Return.Topping3 = item.entity;
                        }

                        if (item.type == "builtin.number")
                        {
                            Return.Number = item.entity;
                        }


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
        #endregion
        // Utility
        #region private static async Task<Example> QueryLUIS(string Query)
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
        #endregion
        [HttpPost]
        public ActionResult SubmitPizza( string size, string cTopping, string mTopping, string vTopping)
        {
            pizza orderedPizza = new pizza();

            string pizzaSize=null;
            Nullable<int> toppingCheese=null;
            Nullable<int> toppingMeat=null;
            Nullable<int> toppingVeg=null;

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
                    break;
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
            using (PizzaContext dc = new PizzaContext())
            {
                dc.pizzas.Add(orderedPizza);
                dc.SaveChanges();
            }


            return RedirectToAction("Submitted");
        }
        public ActionResult Submitted()
        {
            return View();

        }
    }
}