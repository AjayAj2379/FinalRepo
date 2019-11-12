using StudentApplication.BL;
using StudentApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();
        /// <summary>
        /// Get Details of all the Students
        /// </summary>
        /// <param name="stdID">Student Id</param>
        /// <returns>
        /// Returns Student Details list
        /// </returns>

        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            if(Session["Username"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            if(studentAppLogic.CheckStudentID(stdID))
            {
                List<StudentVM> studentList = studentAppLogic.GetStudentData(stdID);
                return View(studentList);
            }

            ViewBag.Message = "Invalid Id";
            return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
           
        }

        /// <summary>
        /// Get Course Details of a particular Student based on Department
        /// </summary>
        /// <param name="deptId">Department Id</param>
        /// <returns>
        /// returns course details of a Student based on department
        /// </returns>      

        [HttpGet]
        public ActionResult CourseDetailsforStudent(string deptId)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<CourseVM> courseDetails = studentAppLogic.GetDepartmentCourses(deptId);
           
            return View(courseDetails);
        }

        /// <summary>
        /// Get Department details of a Student
        /// </summary>
        /// <param name="deptId">Department Id</param>
        /// <returns>
        /// Return Department Details list for a Student 
        /// </returns>
        
        [HttpGet]

        public ActionResult DeptDetailsforStudent(string deptId)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<DepartmentVM> departmentDetails = studentAppLogic.GetDepartmentDetails(deptId);
            return View(departmentDetails);
        }

        /// <summary>
        /// Get Grade Details of a Student 
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>
        /// Returns Grade details List for a student
        /// </returns>
        
        [HttpGet]

        public ActionResult GradeDetailsforStudent(string studentId)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<GradeVM> gradeDetails = studentAppLogic.GetSemGrades(studentId);
            return View(gradeDetails);
        }
    }
}