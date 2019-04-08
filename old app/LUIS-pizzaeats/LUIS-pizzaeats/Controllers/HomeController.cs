using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using Newtonsoft.Json;
using JSONUtils;
using System.Threading.Tasks;


namespace LUIS_pizzaeats.Controllers
{
   public class HomeController : Controller
    {
        #region public async Task<ActionResult> Index(string searchString)
        public async Task<ActionResult> Index(string searchString)
        {
            Query Return = new Query();
            try
            {
                if (searchString != null)
                {
                    LUIS objLUISResult = await QueryLUIS(searchString);
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
                        //if (item.type == "Period")
                        //{
                          //  Return.Period = item.entity;
                        //}
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
