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
            //StudentModel studentModel = new StudentModel();
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

            var count = studentModel;
            sqlConnection.Close();
            return studentModel;
        }



    }
}
