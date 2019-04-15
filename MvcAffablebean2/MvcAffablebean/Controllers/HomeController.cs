using MvcAffablebean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAffablebean.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AffablebeanEntities storeDB = new AffablebeanEntities();
        public ActionResult Index()
        {
            // Get most popular albums
            var products = GetTopSellingAlbums(5);

            return View(products);
        }
        private List<Product> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}