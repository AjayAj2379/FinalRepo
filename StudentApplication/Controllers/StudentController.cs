using StudentApplication.BL;
using StudentApplication.Models;
using System.Web.Mvc;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        public ActionResult Index()
        {
            // object result = studentAppLogic.GetStudentData("STUD040");

            //var config = new MapperConfiguration(cfg =>
            //cfg.CreateMap<object, StudentVM>()
            //);
            //var mapper = config.CreateMapper();

            //StudentVM studentVM = mapper.Map<StudentVM>(result);
            return View();
        }

        [HttpGet]
        public ActionResult StudentDetails(string stdID)
        {
            var studentData = studentAppLogic.GetStudentData("STUD001");

            StudentVM studentVM = new StudentVM();
            string s = studentData.ToString();
            studentVM.studentID = "stud001";
            studentVM.studentName = "Ajay";
            studentVM.studentEmail = "aajkjsakksa";
            studentVM.studentGender = "M";
            studentVM.dateofBirth = "5442561";
            studentVM.departmentName = "stud001";

            return View(studentVM);
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