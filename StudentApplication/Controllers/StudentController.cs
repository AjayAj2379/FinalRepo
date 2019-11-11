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
            //studentVM.studentID = studentData.student.studentID;
            //studentVM.studentName = studentData.student.studentName;
            //studentVM.studentEmail = studentData.student.studentEmail;
            //studentVM.studentGender = studentData.student.studentGender;
            //studentVM.dateofBirth = studentData.student.dateofBirth;
            //studentVM.departmentName = studentData.departName;

            return View();
        }
    }
}