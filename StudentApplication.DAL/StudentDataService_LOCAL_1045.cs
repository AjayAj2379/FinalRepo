using StudentApplication.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentApplication.DAL
{
    public class StudentDataService
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);

        public List<StudentModel> GetStudentData(string studentID)
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<StudentModel> studentModel = new List<StudentModel>();            
            string query = "Select * from Student_Table where StudentID ='"+studentID+"'";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    studentModel.Add(new StudentModel
                    {
                        studentID = sqlDataReader["StudentID"].ToString(),
                        studentName = sqlDataReader["StudentName"].ToString(),
                        studentEmail = sqlDataReader["Email"].ToString(),
                        studentCity = sqlDataReader["City"].ToString(),
                        dateofBirth = sqlDataReader["DateofBirth"].ToString(),
                        studentGender = sqlDataReader["Gender"].ToString(),
                        departmentID = sqlDataReader["DepartmentId"].ToString(),

                    });
                }
            }         
            sqlConnection.Close();
            return studentModel;
        }
        public List<StudentModel> GetStudents()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<StudentModel> studentModel = new List<StudentModel>();
            string query = "Select * from Student_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    studentModel.Add(new StudentModel
                    {
                        studentID = sqlDataReader["StudentID"].ToString(),
                        studentName = sqlDataReader["StudentName"].ToString(),
                        studentEmail = sqlDataReader["Email"].ToString(),
                        studentCity = sqlDataReader["City"].ToString(),
                        dateofBirth = sqlDataReader["DateofBirth"].ToString(),
                        studentGender = sqlDataReader["Gender"].ToString(),
                        departmentID = sqlDataReader["DepartmentId"].ToString(),

                    });
                }
            }
            sqlConnection.Close();
            return studentModel;
        }
        public List<DepartmentModel> GetDepartmentData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<DepartmentModel> departmentModel = new List<DepartmentModel>();            
            string query = "Select * from Department_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    departmentModel.Add(new DepartmentModel
                    {
                        departmentId = sqlDataReader["DepartmentId"].ToString(),
                        departmentHead = sqlDataReader["DepartmentHead"].ToString(),
                        departmentName = sqlDataReader["DepartmentName"].ToString()
                    });
                }
            }
            sqlConnection.Close();
            return departmentModel;
        }

        public List<CourseModel> GetCourseData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<CourseModel> courseModel = new List<CourseModel>();
            string query = "Select * from Course_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    courseModel.Add(new CourseModel
                    {
                        courseId = sqlDataReader["CourseID"].ToString(),
                        courseName = sqlDataReader["CourseName"].ToString(),
                        lecturerId = sqlDataReader["LecturerID"].ToString(),
                        departmentId = sqlDataReader["LecturerID"].ToString(),
                        semesterId = sqlDataReader["SemesterID"].ToString()                      
                    });
                }
            }
            sqlConnection.Close();
            return courseModel;
        }
        public List<GradeModel> GetGradeData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<GradeModel> gradeModel = new List<GradeModel>();
            string query = "Select * from Grade_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    gradeModel.Add(new GradeModel
                    {
                        grade = sqlDataReader["Grade"].ToString(),
                        semesterId=sqlDataReader["SemesterID"].ToString(),
                        studentId=sqlDataReader["StudentID"].ToString()                        
                    });
                }
            }
            sqlConnection.Close();
            return gradeModel;
        }

        public List<SemesterModel> GetSemesterData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<SemesterModel> semesterModel = new List<SemesterModel>();
            string query = "Select * from Semester_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    semesterModel.Add(new SemesterModel
                    {
                        semesterId = sqlDataReader["SemesterID"].ToString(),
                        semesterName = sqlDataReader["SemesterNumber"].ToString(),
                        semesterMontYear=sqlDataReader["SemesterMonth_Year"].ToString()
                    });
                }
            }
            sqlConnection.Close();
            return semesterModel;
        }

        public List<LecturerModel> GetLecturerData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<LecturerModel> lecturerModel = new List<LecturerModel>();
            string query = "Select * from Lecturer_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lecturerModel.Add(new LecturerModel
                    {
                     lecturerId=sqlDataReader["LecturerId"].ToString(),
                     lecturerName=sqlDataReader["LecturerName"].ToString(),
                     email=sqlDataReader["Email"].ToString(),
                     phoneNumber=sqlDataReader["PhoneNumber"].ToString(),
                     departmentId=sqlDataReader["DepartmentID"].ToString()
                    });
                }
            }
            sqlConnection.Close();
            return lecturerModel;
        }

        public List<LibraryModel> GetLibraryData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<LibraryModel> libraryModel = new List<LibraryModel>();
            string query = "Select * from Libraryr_Table";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    libraryModel.Add(new LibraryModel
                    {
                     courseId=sqlDataReader["CourseID"].ToString(),
                     authorName=sqlDataReader["AuthorName"].ToString(),
                     rackNumber=sqlDataReader["RackNumber"].ToString(),
                     yearOfPublishing=sqlDataReader["YearofPublishing"].ToString()   
                    });
                }
            }
            sqlConnection.Close();
            return libraryModel;
        }
    }
}
