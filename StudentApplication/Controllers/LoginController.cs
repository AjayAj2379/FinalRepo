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

            }
            else
            {
                ViewBag.Message = "Enter the correct login details";
            }
            return View(loginModel);
        }

    }
}