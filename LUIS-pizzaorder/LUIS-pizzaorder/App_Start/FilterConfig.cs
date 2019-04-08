using System.Web;
using System.Web.Mvc;

namespace LUIS_pizzaorder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
