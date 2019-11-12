using StudentApplication.BL;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class SemesterController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();
        /// <summary>
        /// Get Details of a Semester
        /// </summary>
        /// <returns>
        /// Returns Semester details list 
        /// </returns>
       
        public ActionResult GetSemesterDetails()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<SemesterVM> semesterDetails = studentAppLogic.GetAllSemesterDetails();
            return View(semesterDetails);
        }
    }
}