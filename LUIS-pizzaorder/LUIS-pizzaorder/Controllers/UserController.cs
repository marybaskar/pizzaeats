using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LUIS_pizzaorder.Models;

namespace LUIS_pizzaorder.Controllers
{
    public class UserController : Controller
    {
        //Register
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration([Bind(Exclude = "user_id")] user newUser)
        {
            bool Status = false;
            string Message = "";

            if(ModelState.IsValid)
            {

            }
            else
            {
                Message = "Invalid Request";
            }
            return View(newUser);
        }
       // [NonAction]
       // public bool usernameExists(string username)
       // {
       //     using (
       // }

        //Login

        //LogOut
    }
}