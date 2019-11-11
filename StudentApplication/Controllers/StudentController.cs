using StudentApplication.BL;
using StudentApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();


        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            List<StudentVM> studentList = studentAppLogic.GetStudentData(stdID);
            return View(studentList);
        }
        [HttpGet]
        public ActionResult CourseDetailsforStudent()
        {

            return View();
        }

        [HttpGet]

        public ActionResult DeptDetailsforStudent()
        {
            return View();
        }
        [HttpGet]

        public ActionResult GradeDetailsforStudent()
        {
            return View();
        }
    }
}