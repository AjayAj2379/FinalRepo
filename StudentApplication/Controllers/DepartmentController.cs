using StudentApplication.BL;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class DepartmentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        [HttpGet]
        public ActionResult GetDepartmentDetails()
        {
            List<DepartmentVM> deptDetails = studentAppLogic.GetAllDepartmentDetails();
            return View();
        }
        [HttpGet]
        public ActionResult StaffDetailsbyDept()
        {

            return View();
        }
    }
}