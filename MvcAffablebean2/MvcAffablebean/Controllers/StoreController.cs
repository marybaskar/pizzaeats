using MvcAffablebean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAffablebean.Controllers
{
    public class StoreController : Controller
    {
        AffablebeanEntities storeDB = new AffablebeanEntities();
        // GET: Store
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string category)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Categories.Include("Products").Single(g => g.Name == category);
            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
        }
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);
        }
    }
}