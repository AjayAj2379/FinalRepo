using StudentApplication.BL;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class LibraryController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        public ActionResult GetLibraryDetails(string courseID)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<LibraryVM> libraryDetails = studentAppLogic.GetLibraryDetails(courseID);
            return View(libraryDetails);
        }
    }
}