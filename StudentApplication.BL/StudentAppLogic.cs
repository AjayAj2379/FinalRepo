using StudentApplication.DAL;
using StudentApplication.Model;
using System.Collections;
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

            object result = studentList.Join(
                departmentList,
                student => student.departmentID,
                department => department.departmentId,

                (student, department) => new
                {
                    student,
                    departName = department.departmentName
                }
                );

            return result;
        }

        public object GetSemGrades(string studentID)
        {
            var gradeList = studentDataService.GetGradeData().Where(gradeDetails =>
            gradeDetails.studentId.Equals(studentID)
            );

            
            var semesterList = studentDataService.GetSemesterData().Where(
                semDetails => semDetails.semesterId.Equals(gradeList.Select(s => s.semesterId))
                );
          

            var result = gradeList.Join(
                semesterList,
                grade => grade.semesterId,
                semester => semester.semesterId,

                (grade, semester) => new
                {
                    grade = grade.grade,
                    semesterName = semester.semesterName,
                    semesterMontYear = semester.semesterMontYear
                }
                );
            return result;
        }

        public object GetCourses(string semesterID)
        {
            var courseList = studentDataService.GetCourseData().Where(semDetails =>
           semDetails.semesterId.Equals(semesterID)
           ).Select(semDetails => semDetails.courseName)
           ;

            return courseList;
        }

        public object GetTeachers(string subjectName)
        {

            var courseList = studentDataService.GetCourseData().Where(courseDetails =>
            courseDetails.courseName.Equals(subjectName)
            );

            var teacherList = studentDataService.GetLecturerData();

            var result = courseList.Join(
              teacherList,
              course => course.lecturerId,
              teacher => teacher.lecturerId,

              (course, teacher) => new
              {
                  lecturerName = teacher.lecturerName
              }
              );
            return result;
        }

        public object GetTeacherDetails(string lecturerId)
        {
            var result = studentDataService.GetLecturerData().Where(teacher =>
             teacher.lecturerId.Equals(lecturerId)
             );
            return result;
        }

        public object GetStudents(string lecturerId)
        {
            var teacherList = studentDataService.GetLecturerData().Where(teacher =>
            teacher.lecturerId.Equals(lecturerId)
            );

            var studentsList = studentDataService.GetStudents();

            var result = teacherList.Join(
                studentsList,
                teacher => teacher.departmentId,
                student => student.departmentID,
                (teacher,student) => new
                {
                    students = student
                }
                );
            return result;
        }
    }
}
