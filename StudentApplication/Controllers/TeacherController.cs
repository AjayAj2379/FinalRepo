using StudentApplication.BL;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{

    public class TeacherController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        /// <summary>
        /// Get Details of a Teacher
        /// </summary>
        /// <param name="lecturerID">Lecturer Id</param>
        /// <returns>
        /// Returns Lecturer Details List
        /// </returns>
        
        [HttpGet]               
       public ActionResult GetTeacherDetails(string lecturerID)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if(studentAppLogic.CheckLecturerID(lecturerID))
            {
                List<LecturerVM> lecturerDetails = studentAppLogic.GetTeacherDetails(lecturerID);
                return View(lecturerDetails);
            }

            ViewBag.Message("Invaid ID");
            return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Get Course details of a Teacher
        /// </summary>
        /// <param name="lecturerID">Lecturer Id</param>
        /// <returns>
        /// Returns Course Details List of a Teacher
        /// </returns>     

        [HttpGet]
        public ActionResult CourseDetailsforTeacher(string lecturerID)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<CourseVM> courseDetails = studentAppLogic.GetTeacherCourses(lecturerID);
            return View(courseDetails);
        }

        /// <summary>
        /// Get Department details of a Teacher
        /// </summary>
        /// <param name="deptID">Department Id</param>
        /// <returns>
        /// Returns Departrment details list of a Teacher
        /// </returns>

        public ActionResult DeptDetailsforTeacher(string deptID)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<DepartmentVM> departmentDetails = studentAppLogic.GetDepartmentDetails(deptID);
            return View(departmentDetails);
        }
    }
}