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
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

       

      
    }
}