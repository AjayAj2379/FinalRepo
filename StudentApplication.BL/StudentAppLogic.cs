using StudentApplication.DAL;
using StudentApplication.Model;
using StudentApplication.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentApplication.BL
{
    
 public class StudentAppLogic
    {
        StudentDataService studentDataService = new StudentDataService();

        public List<StudentVM> GetStudentData (string studentID)
        {
            StudentVM studentVM = new StudentVM();
            List<StudentModel> studentList = studentDataService.GetStudentData(studentID);
            List<DepartmentModel> departmentList = studentDataService.GetDepartmentData();

            var result = studentList.Join(
                departmentList,
                student => student.departmentID,
                department => department.departmentId,

                (student, department) => new StudentVM
                {
                    studentID = student.studentID,
                    studentName = student.studentName,
                    studentEmail = student.studentEmail,
                    studentGender = student.studentGender,
                    dateofBirth = student.dateofBirth,
                    departmentName = department.departmentName
                }
                ).ToList();
          
            return result;
        }

        public List<GradeVM> GetSemGrades(string studentID)
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

                (grade, semester) => new GradeVM
                {
                    grade = grade.grade,
                    semesterName = semester.semesterName,
                    semesterMontYear = semester.semesterMontYear
                }
                ).ToList();
                 
            
            return result;
        }

        public List<CourseVM> GetDepartmentCourses(string departmentID)
        {
            var courseList = studentDataService.GetCourseData().Where(course =>
           course.departmentId.Equals(departmentID)
           ).Select(course => new CourseVM {
               courseId = course.courseId,
               courseName = course.courseName,
               semesterId = course.semesterId
           }).ToList();
     
            return courseList;
        }

        public List<CourseVM> GetTeacherCourses(string lecturerID)
        {
            var courseList = studentDataService.GetCourseData().Where(course =>
           course.lecturerId.Equals(lecturerID)
           ).Select(course => new CourseVM
           {
               courseId = course.courseId,
               courseName = course.courseName,
               semesterId = course.semesterId
           }).ToList();

            return courseList;
        }

        public List<LibraryVM> GetLibraryDetails(string courseId)
        {
            var libraryDetails = studentDataService.GetLibraryData().Where(library =>
           library.courseId.Equals(courseId));

            var courseDetails = studentDataService.GetCourseData().Where(course =>
          course.courseId.Equals(courseId));

            var result = libraryDetails.Join(
                courseDetails,
                library => library.courseId,
                course => course.courseId,
                (library,course) => new LibraryVM{
                    courseId = library.courseId,
                    courseName = course.courseName,
                    authorName = library.authorName,
                    rackNumber = library.rackNumber,
                    yearOfPublishing = library.yearOfPublishing
                }
                ).ToList();
            return result;
        }
        //public ArrayList GetTeachers(string subjectName)
        //{

        //    var courseList = studentDataService.GetCourseData().Where(courseDetails =>
        //    courseDetails.courseName.Equals(subjectName)
        //    );

        //    var teacherList = studentDataService.GetLecturerData();

        //    var result = courseList.Join(
        //      teacherList,
        //      course => course.lecturerId,
        //      teacher => teacher.lecturerId,

        //      (course, teacher) => new
        //      {
        //          lecturerName = teacher.lecturerName
        //      }
        //      );

        //    ArrayList list = new ArrayList();
        //    foreach (var item in courseList)
        //    {
        //        list.Add(item);
        //    }
        //    return list;

        //}

        public List<LecturerVM> GetTeacherDetails(string lecturerId)
        {
            var lecturerDetails = studentDataService.GetLecturerData().Where(teacher =>
             teacher.lecturerId.Equals(lecturerId));

            var dept = studentDataService.GetDepartmentData();

            var result = lecturerDetails.Join(
                dept,
                lecturer => lecturer.departmentId,
                department => department.departmentId,
                (lecturer,department) => new LecturerVM
                {
                    lecturerId = lecturer.lecturerId,
                    lecturerName = lecturer.lecturerName,
                    email = lecturer.email,
                    phoneNumber = lecturer.phoneNumber,
                    departmentId = lecturer.departmentId,
                    departmentName = department.departmentName
                }
                ).ToList();
            return result;
        }

        //public ArrayList GetStudents(string lecturerId)
        //{
        //    var teacherList = studentDataService.GetLecturerData().Where(teacher =>
        //    teacher.lecturerId.Equals(lecturerId)
        //    );

        //    var studentsList = studentDataService.GetStudents();

        //    var result = teacherList.Join(
        //        studentsList,
        //        teacher => teacher.departmentId,
        //        student => student.departmentID,
        //        (teacher,student) => new
        //        {
        //            students = student
        //        }
        //        );
        //    ArrayList list = new ArrayList();
        //    foreach (var item in result)
        //    {
        //        list.Add(item);
        //    }
        //    return list;
        //}

        public List<DepartmentVM> GetDepartmentDetails(string deptID)
        {
            var deptData = studentDataService.GetDepartmentData().Where(dept=>
            dept.departmentId.Equals(deptID))
            .Select(department => new DepartmentVM
            {
                departmentId = department.departmentId,
                departmentName= department.departmentName,
                departmentHead= department.departmentHead
            }
                
                ).ToList();

            return deptData;
        }

       

    }
}
