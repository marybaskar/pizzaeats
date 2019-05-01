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
        //Home
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
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
                bool isExist = UsernameExists(newUser.username);
                if(isExist)
                {
                    ModelState.AddModelError("UsernameExist", "Username already exists");
                    return View(newUser);

                }

                newUser.password = Crypto.Hash(newUser.password);
                newUser.comfirmpassword = Crypto.Hash(newUser.comfirmpassword);

                using (UserContext dc = new UserContext())
                {
                    dc.users.Add(newUser);
                    dc.SaveChanges();
                }
                return RedirectToAction("Login");
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewBag.Status = Status;
            return View(newUser);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin login)
        {
            string Message = "";
            using (UserContext dc = new UserContext())
            {
                var v = dc.users.Where(a => a.username == login.username).FirstOrDefault();
                if(v!=null)
                {
                    string hashedPassword = Crypto.Hash(login.password);
                    if (string.Compare(hashedPassword, v.password)==0)
                    {
                        Session["UserID"] = v.user_id.ToString();
                        Session["UserName"] = v.username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    else
                    {
                        Message = "Incorrect Password";
                    }
                }
                else { Message = "Username doesnot exist"; }
            }

            ViewBag.Message = Message;
            return View();
        }


        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        
        public ActionResult Signout()
        {
            Session.Abandon();
            return View("Login");
        }

        [NonAction]
       public bool UsernameExists(string username)
       {
            using (UserContext dc = new UserContext())
            {
                var v = dc.users.Where(a => a.username == username).FirstOrDefault();
                return v != null;
            }
       }


        //Login

        //LogOut
    }
}