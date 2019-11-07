using StudentApplication.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentApplication.DAL
{
    public class StudentDataService
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);

        public List<StudentModel> GetStudentData()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            List<StudentModel> studentModel = new List<StudentModel>();
            //StudentModel studentModel = new StudentModel();
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

            var count = studentModel;
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

        // Ajay

    }
}
