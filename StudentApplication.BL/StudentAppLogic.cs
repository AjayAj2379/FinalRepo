using StudentApplication.DAL;
using StudentApplication.Model;

using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApplication.BL
{

    public class StudentAppLogic
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        StudentDataService studentDataService = new StudentDataService();

        /// <summary>
        /// Gets list containing details of a particular student
        /// </summary>
        /// <param name="studentID">ID of a particular Student</param>
        /// <returns>Generic list of type Student View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<StudentVM> GetStudentData(string studentID)
        {

            List<StudentVM> result = new List<StudentVM>();
            try
            {
                StudentVM studentVM = new StudentVM();
                List<StudentModel> studentList = studentDataService.GetStudentData(studentID);
                List<DepartmentModel> departmentList = studentDataService.GetDepartmentData();

                result = studentList.Join(
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
                        departmentName = department.departmentName,
                        depatmentID = department.departmentId
                    }
                    ).ToList(); 

            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return result;
        }

        /// <summary>
        /// Returns grade and Semester details of a particular student
        /// </summary>
        /// <param name="studentID">ID of a particular Student</param>
        /// <returns>Generic list of type Grade View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<GradeVM> GetSemGrades(string studentID)
        {
            List<GradeVM> result = new List<GradeVM>();
            try
            {
                var gradeList = studentDataService.GetGradeData().Where(gradeDetails =>
          gradeDetails.studentId.Equals(studentID)
          );
                var semesterList = studentDataService.GetSemesterData();

                result = gradeList.Join(
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
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return result;
        }

        /// <summary>
        /// Returns Course details of a particular Department
        /// </summary>
        /// <param name="departmentID">ID of a particular Department</param>
        /// <returns>Generic list of type Course View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<CourseVM> GetDepartmentCourses(string departmentID)
        {
            List<CourseVM> courseList = new List<CourseVM>();
            try
            {
                courseList = studentDataService.GetCourseData().Where(course =>
           course.departmentId.Equals(departmentID)
           ).Select(course => new CourseVM
           {
               courseId = course.courseId,
               courseName = course.courseName,
               semesterId = course.semesterId,
               departmentId = course.departmentId

           }).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return courseList;
        }

        /// <summary>
        /// Returns details of the courses handled by particular lecturer
        /// </summary>
        /// <param name="lecturerID">ID of a particular lecturer</param>
        /// <returns>Generic list of type Course View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<CourseVM> GetTeacherCourses(string lecturerID)
        {
            List<CourseVM> courseList = new List<CourseVM>();
            try
            {
                courseList = studentDataService.GetCourseData().Where(course =>
          course.lecturerId.Equals(lecturerID)
          ).Select(course => new CourseVM
          {
              courseId = course.courseId,
              courseName = course.courseName,
              semesterId = course.semesterId,
              departmentId = course.departmentId,

          }).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return courseList;
        }

        /// <summary>
        /// Returns library details of a particular Course
        /// </summary>
        /// <param name="courseId">ID of a particular course</param>
        /// <returns>Generic list of type Library View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<LibraryVM> GetLibraryDetails(string courseId)
        {
            List<LibraryVM> result = new List<LibraryVM>();
            try
            {
                var libraryDetails = studentDataService.GetLibraryData().Where(library =>
          library.courseId.Equals(courseId));

                var courseDetails = studentDataService.GetCourseData().Where(course =>
              course.courseId.Equals(courseId));

                 result = libraryDetails.Join(
                     courseDetails,
                     library => library.courseId,
                     course => course.courseId,
                     (library, course) => new LibraryVM
                     {
                         courseId = library.courseId,
                         courseName = course.courseName,
                         authorName = library.authorName,
                         rackNumber = library.rackNumber,
                         yearOfPublishing = library.yearOfPublishing
                     }
                     ).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return result;
        }

        public List<LecturerVM> GetTeacherbyDept (string deptID)
        {
            List<LecturerVM> lecturerDetails = new List<LecturerVM>();
            try
            {
                 lecturerDetails = studentDataService.GetLecturerData().Where(teacher =>
            teacher.departmentId.Equals(deptID)).Select( lecturer => new LecturerVM
                    {
                        lecturerId = lecturer.lecturerId,
                        lecturerName = lecturer.lecturerName,
                        email = lecturer.email,
                        phoneNumber = lecturer.phoneNumber,
                        departmentId = lecturer.departmentId,
                       
                    }
                    ).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return lecturerDetails;
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

        /// <summary>
        /// Returns details of a particular lecturer
        /// </summary>
        /// <param name="lecturerId">ID of a particular lecturer</param>
        /// <returns>Generic list of type Lecturer View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<LecturerVM> GetTeacherDetails(string lecturerId)
        {
            List<LecturerVM> result = new List<LecturerVM>();

            try
            {
                var lecturerDetails = studentDataService.GetLecturerData().Where(teacher =>
            teacher.lecturerId.Equals(lecturerId));

                var dept = studentDataService.GetDepartmentData();

                result = lecturerDetails.Join(
                    dept,
                    lecturer => lecturer.departmentId,
                    department => department.departmentId,
                    (lecturer, department) => new LecturerVM
                    {
                        lecturerId = lecturer.lecturerId,
                        lecturerName = lecturer.lecturerName,
                        email = lecturer.email,
                        phoneNumber = lecturer.phoneNumber,
                        departmentId = lecturer.departmentId,
                        departmentName = department.departmentName
                    }
                    ).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
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

        /// <summary>
        /// Returns details of a particular department
        /// </summary>
        /// <param name="deptID">ID of a particular department</param>
        /// <returns>Generic list of type Department View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<DepartmentVM> GetDepartmentDetails(string deptID)
        {
            List<DepartmentVM> deptData = new List<DepartmentVM>();

            try
            {
             deptData = studentDataService.GetDepartmentData().Where(dept =>
                  dept.departmentId.Equals(deptID))
                  .Select(department => new DepartmentVM
                  {
                      departmentId = department.departmentId,
                      departmentName = department.departmentName,
                      departmentHead = department.departmentHead
                  }
                 ).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return deptData;
        }

        /// <summary>
        /// Returns the details of all Departments
        /// </summary>
        /// <returns>Generic list of type Department View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<DepartmentVM> GetAllDepartmentDetails()
        {
            List<DepartmentVM> deptDetails = new List<DepartmentVM>();

            try
            {
                deptDetails = studentDataService.GetDepartmentData().Select(department => new DepartmentVM
                {
                    departmentId = department.departmentId,
                    departmentName = department.departmentName,
                    departmentHead = department.departmentHead

                }
                ).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return deptDetails;
        }

        /// <summary>
        /// Returns the details of all Semesters
        /// </summary>
        /// <returns>Generic list of type Semester View model</returns>
        /// <exception cref="Exception">Handles Exception</exception>
        public List<SemesterVM> GetAllSemesterDetails()
        {
            List<SemesterVM> semeterDetails = new List<SemesterVM>();
            try
            {
                semeterDetails = studentDataService.GetSemesterData().Select(semester => new SemesterVM
                {
                    semesterId = semester.semesterId,
                    semesterName = semester.semesterName,
                    semesterMontYear = semester.semesterMontYear
                }).ToList();
            }
            catch (Exception exception)
            {
                log.Info("\n----------Exception------\n");
                log.Error(exception.ToString());
            }
            return semeterDetails;
        }

        /// <summary>
        /// Returns whether the given studentID is existing or not
        /// </summary>
        /// <param name="studentID">Id of a particular student</param>
        /// <returns>True or False</returns>
        public bool CheckStudentID(string studentID)
        {
            return studentDataService.CheckStudentID(studentID);
        }

        /// <summary>
        /// Returns whether the given lecturerID is existing or not
        /// </summary>
        /// <param name="lecturerID">Id of a particular lecturer</param>
        /// <returns>True or False</returns>
        public bool CheckLecturerID(string lecturerID)
        {
            return studentDataService.CheckLecturerID(lecturerID);
        }

    }
}
