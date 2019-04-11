using JSONUtils;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Configuration;
namespace LUISPizzaOrder.Controllers
{   
    public class HomeController : Controller
    {
        #region public async Task<ActionResult> Index(string String)
        public async Task<ActionResult> Index(string String)
        {
            Query Return = new Query();
            try
            {
                if (String != null)
                {

                    LUIS objLUISResult = await QueryLUIS(String);
                    LUIS iLUISResult = await QueryLUIS(String);
                    foreach (var i in iLUISResult.intents)
                    {    if (i.intent == "Greeting")
                        { 
                            Return.Greeting = ("Hello this pizzaeats how can i help you");

                        }
                        else if (i.intent == "pizzaOrder")
                        {
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
                                

                                if (item.type == "builtin.number")
                                {
                                    Return.Number = item.entity;
                                }

                                


                            }
                        }
                        else if (i.intent == "None")
                        {
                            Return.None = ("sorry i don't understand");


                        }
                               

                        }

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
    }
}