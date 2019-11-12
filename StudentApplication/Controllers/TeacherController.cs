using StudentApplication.BL;
using StudentApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{

    public class TeacherController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

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