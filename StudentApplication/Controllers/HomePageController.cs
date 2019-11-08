using StudentApplication.BL;
using StudentApplication.Models;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class HomePageController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();
       
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            dynamic studentData = studentAppLogic.GetStudentData("STUD001");

            StudentVM studentVM = new StudentVM();
            string s = studentData.ToString();
            studentVM.studentID = studentData.student.studentID;
            studentVM.studentName = studentData.student.studentName;
            studentVM.studentEmail = studentData.student.studentEmail;
            studentVM.studentGender = studentData.student.studentGender;
            studentVM.dateofBirth = studentData.student.dateofBirth;
            studentVM.departmentName = studentData.departName;

            return View();
         }

      
    }
}