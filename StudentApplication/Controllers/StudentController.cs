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
        /// 
        /// </summary>
        /// <param name="stdID"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            if(Session["Username"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<StudentVM> studentList = studentAppLogic.GetStudentData(stdID);
            return View(studentList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

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
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
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