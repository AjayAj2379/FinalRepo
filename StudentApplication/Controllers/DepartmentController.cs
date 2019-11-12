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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<DepartmentVM> deptDetails = studentAppLogic.GetAllDepartmentDetails();
            return View(deptDetails);
        }

        public ActionResult StaffDetailsbyDept(string deptID)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<LecturerVM> lecturerDetails = studentAppLogic.GetTeacherbyDept(deptID);
            return View(lecturerDetails);
        }
     
    }
}