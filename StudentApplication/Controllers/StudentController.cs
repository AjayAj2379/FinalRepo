using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApplication.BL;
using StudentApplication.Models;
using AutoMapper;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentAppLogic studentAppLogic = new StudentAppLogic();

        public ActionResult Index()
        {
             object result = studentAppLogic.GetStudentData("STUD040");

            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<object, StudentVM>()
            );
            var mapper = config.CreateMapper();

            StudentVM studentVM = mapper.Map<StudentVM>(result);
            return View();
        }

    }
}