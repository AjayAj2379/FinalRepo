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
        /// <summary>
        /// Get Details of all Department 
        /// </summary>
        /// <returns>
        /// Return Department Details List
        /// </returns>
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

        /// <summary>
        /// Get Staff Details based on Department
        /// </summary>
        /// <param name="deptID">Department Id</param>
        /// <returns>
        /// Return Lecturer Details List
        /// </returns>
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