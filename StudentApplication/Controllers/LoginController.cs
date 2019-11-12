using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Method to Check User details and Login
        /// </summary>
        /// <returns></returns>
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginVM loginModel)
        {
            if(loginModel.userName=="admin" && loginModel.password=="admin@123")
            {
                Session["Username"] = loginModel.userName;
                return RedirectToAction("HomePage", "Homepage");
            }
            else
            {
                ViewBag.Message = "Enter the correct login details";
            }
            return View(loginModel);
        }
        /// <summary>
        /// Method to Logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}