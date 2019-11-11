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

        public ArrayList GetStudentData (string studentID)
        {
            List<StudentModel> studentList = studentDataService.GetStudentData(studentID);

            List<DepartmentModel> departmentList = studentDataService.GetDepartmentData();

            var result = studentList.Join(
                departmentList,
                student => student.departmentID,
                department => department.departmentId,

                (student, department) => new
                {
                    student,
                    departName = department.departmentName
                }
                );
            ArrayList list = new ArrayList();
            foreach(var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetSemGrades(string studentID)
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
                 
            ArrayList list = new ArrayList();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetCourses(string semesterID)
        {
            var courseList = studentDataService.GetCourseData().Where(semDetails =>
           semDetails.semesterId.Equals(semesterID)
           ).Select(semDetails => semDetails.courseName)
           ;

             
            ArrayList list = new ArrayList();
            foreach (var item in courseList)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetTeachers(string subjectName)
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

            ArrayList list = new ArrayList();
            foreach (var item in courseList)
            {
                list.Add(item);
            }
            return list;
  
        }

        public ArrayList GetTeacherDetails(string lecturerId)
        {
            var result = studentDataService.GetLecturerData().Where(teacher =>
             teacher.lecturerId.Equals(lecturerId)
             );

            ArrayList list = new ArrayList();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetStudents(string lecturerId)
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
            ArrayList list = new ArrayList();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetDepartmentDetails(string deptID)
        {
            var deptData = studentDataService.GetDepartmentData().Where(dept=>
            dept.departmentId.Equals(deptID)
                );

            ArrayList list = new ArrayList();
            foreach (var item in deptData)
            {
                list.Add(item);
            }
            return list;
        }

        public ArrayList GetCourseDetails(string deptID)
        {
            var courseData = studentDataService.GetCourseData().Where(course =>
            course.departmentId.Equals(deptID)
                );

            ArrayList list = new ArrayList();
            foreach (var item in courseData)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
