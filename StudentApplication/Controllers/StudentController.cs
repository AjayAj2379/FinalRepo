using StudentApplication.BL;
using StudentApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        public ActionResult Index()
        {
         
            return View();
        }

        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            List<StudentVM> studentList = studentAppLogic.GetStudentData(stdID);
            return View(studentList);
        }

        public ActionResult CourseDetailsforStudent()
        {

            return View();
        }
    }
}