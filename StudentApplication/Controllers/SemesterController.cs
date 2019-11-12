using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class SemesterController : Controller
    {
        // GET: Semester
        public ActionResult Index()
        {
            return View();
        }
    }
}