using StudentApplication.Model;
using System.Collections.Generic;

namespace StudentApplication.DAL.Interfaces
{
    interface IDatabaseOperations
    {
        bool CheckStudentID(string studentID);
        List<StudentModel> GetStudentData(string studentID);
        List<StudentModel> GetStudents();
        List<DepartmentModel> GetDepartmentData();
        List<CourseModel> GetCourseData();
        List<GradeModel> GetGradeData();
        List<SemesterModel> GetSemesterData();
        bool CheckLecturerID(string lecturerID);
        List<LecturerModel> GetLecturerData();
        List<LibraryModel> GetLibraryData();

    }
}
