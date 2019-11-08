using StudentApplication.DAL;
using StudentApplication.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentApplication.BL
{
    
 public class StudentAppLogic
    {
        StudentDataService studentDataService = new StudentDataService();

        public object GetStudentData (string studentID)
        {
            List<StudentModel> studentList = studentDataService.GetStudentData(studentID);

            List<DepartmentModel> departmentList = studentDataService.GetDepartmentData();

            var result = studentList.Join(
                departmentList,
                student => student.departmentID,
                department => department.departmentId,

                (student, department) => new
                {
                    studentID = student.studentID,
                    studentName = student.studentName,
                    dateofBirth = student.dateofBirth,
                    studentEmail = student.studentEmail,
                    studentGender = student.studentGender,
                    departName = department.departmentName
                }
                );
            
            return result;
        }
    }
}
