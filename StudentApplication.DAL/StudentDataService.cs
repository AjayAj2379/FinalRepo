using StudentApplication.DAL.Interfaces;
using StudentApplication.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentApplication.DAL
{
    /// <summary>
    /// Implements IDatabaseOperations interface
    /// </summary>
    public class StudentDataService : IDatabaseOperations
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);

        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Check whether the given studentID is present in the Student Table
        /// </summary>
        /// <param name="studentID">Id of a student</param>
        /// <returns>True or False</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public bool CheckStudentID(string studentID)
        {
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;
                string query = "Select * from Student_Table where StudentID ='" + studentID + "'";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------");
                log.Error(sqlexception.ToString());
                bool exception = Convert.ToBoolean(sqlexception);
                return exception;

            }
            finally
            {
                sqlConnection.Close();
            }

        }

        /// <summary>
        /// Returns details of a particular student
        /// </summary>
        /// <param name="studentID">Id of a student</param>
        /// <returns>Generic list of type Student Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<StudentModel> GetStudentData(string studentID)
        {
            List<StudentModel> studentModel = new List<StudentModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;
                string query = "Select * from Student_Table where StudentID ='" + studentID + "'";
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
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return studentModel;
        }

        /// <summary>
        /// Returns the details of all Students
        /// </summary>
        /// <returns>Generic list of type Student Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<StudentModel> GetStudents()
        {
            List<StudentModel> studentModel = new List<StudentModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;
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

            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return studentModel;
        }

        /// <summary>
        /// Returns the details of all departments
        /// </summary>
        /// <returns>Generic list of type Department Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<DepartmentModel> GetDepartmentData()
        {
            List<DepartmentModel> departmentModel = new List<DepartmentModel>();

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

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
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return departmentModel;
        }

        /// <summary>
        /// Returns the details of all Courses
        /// </summary>
        /// <returns>Generic list of type Course Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<CourseModel> GetCourseData()
        {
            List<CourseModel> courseModel = new List<CourseModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

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
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return courseModel;
        }

        /// <summary>
        /// Returns the details of all grades
        /// </summary>
        /// <returns>Generic list of type Grade Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<GradeModel> GetGradeData()
        {
            List<GradeModel> gradeModel = new List<GradeModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

                string query = "Select * from Grade_Table";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        gradeModel.Add(new GradeModel
                        {
                            grade = sqlDataReader["Grade"].ToString(),
                            semesterId = sqlDataReader["SemesterID"].ToString(),
                            studentId = sqlDataReader["StudentID"].ToString()
                        });
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return gradeModel;
        }

        /// <summary>
        /// Returns the details of all Semesters
        /// </summary>
        /// <returns>Generic list of type Semester Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<SemesterModel> GetSemesterData()
        {
            List<SemesterModel> semesterModel = new List<SemesterModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

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
                            semesterMontYear = sqlDataReader["SemesterMonth_Year"].ToString()
                        });
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return semesterModel;
        }

        /// <summary>
        /// Check whether the given lecturerID is present in the Student Table
        /// </summary>
        /// <param name="studentID">Id of a lecturer</param>
        /// <returns>True or False</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public bool CheckLecturerID(string lecturerID)
        {
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;
                string query = "SELECT * from Lecturer_Table  where LecturerId ='" + lecturerID + "'";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------");
                log.Error(sqlexception.ToString());
                bool exception = Convert.ToBoolean(sqlexception);
                return exception;

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Returns the details of all Lecturers
        /// </summary>
        /// <returns>Generic list of type Lecturer Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<LecturerModel> GetLecturerData()
        {
            List<LecturerModel> lecturerModel = new List<LecturerModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

                string query = "Select * from Lecturer_Table";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        lecturerModel.Add(new LecturerModel
                        {
                            lecturerId = sqlDataReader["LecturerId"].ToString(),
                            lecturerName = sqlDataReader["LecturerName"].ToString(),
                            email = sqlDataReader["Email"].ToString(),
                            phoneNumber = sqlDataReader["PhoneNumber"].ToString(),
                            departmentId = sqlDataReader["DepartmentID"].ToString()
                        });
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return lecturerModel;
        }


        /// <summary>
        /// Returns the library details
        /// </summary>
        /// <returns>Generic list of type Library Model</returns>
        /// <exception cref="SqlException">Handles sql exceptions</exception>
        public List<LibraryModel> GetLibraryData()
        {
            List<LibraryModel> libraryModel = new List<LibraryModel>();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = null;

                string query = "Select * from Library_Table";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        libraryModel.Add(new LibraryModel
                        {
                            courseId = sqlDataReader["CourseID"].ToString(),
                            authorName = sqlDataReader["AuthorName"].ToString(),
                            rackNumber = Convert.ToInt32(sqlDataReader["RackNumber"]),
                            yearOfPublishing = Convert.ToInt64(sqlDataReader["YearofPublising"])
                        });
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                log.Info("\n------------Sql Exception------\n");
                log.Error(sqlexception.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return libraryModel;
        }
    }
}
