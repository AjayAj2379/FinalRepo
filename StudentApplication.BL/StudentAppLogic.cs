using StudentApplication.DAL;



namespace StudentApplication.BL
{
    
 public class StudentAppLogic
    {
        StudentDataService studentDataService = new StudentDataService();

        public void GetStudentData()
        {
            var result = studentDataService.GetStudentData("STUD001");
        }
    }
}
