using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class TeacherController : Controller
    {
       [HttpGet]
       
       public ActionResult GetTeacherDetails()
        {

            return View();
        }

        [HttpGet]

        public ActionResult CourseDetailsforTeacher()
        {
            return View();
        }

        public ActionResult DeptDetailsforTeacher()
        {
            return View();
        }
    }
}