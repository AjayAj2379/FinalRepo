using StudentApplication.DAL;
using StudentApplication.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentApplication.BL
{
    
 public class StudentAppLogic
    {
        StudentDataService studentDataService = new StudentDataService();

        public dynamic GetStudentData(string studentID)
        {

        List<StudentModel> result = studentDataService.GetStudentData();

           

            
          
            return result;
        }
    }
}
