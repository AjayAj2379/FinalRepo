using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet]

        public ActionResult GetDepartmentDetails()
        {

            return View();
        }

        [HttpGet]

        public ActionResult StaffDetailsbyDept()
        {

            return View();
        }
    }
}