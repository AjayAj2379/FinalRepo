using StudentApplication.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentApplication.DAL
{
    public class StudentDataService
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);

        public object GetStudentData(string studentID)
        {
            SqlDataReader sqlDataReader = null;

            StudentModel studentModel = new StudentModel();
            using (SqlCommand sqlCommand = new SqlCommand("Select * from Student_Table where StudentID " + studentID + "", sqlConnection))
            {
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    studentModel = new StudentModel
                    {
                        studentID = sqlDataReader["StudentID"].ToString(),
                        studentName = sqlDataReader["StudentName"].ToString(),
                        studentEmail = sqlDataReader["Email"].ToString(),
                        studentCity = sqlDataReader["City"].ToString(),
                        dateofBirth = sqlDataReader["DateofBirth"].ToString(),
                        studentGender = sqlDataReader["Gender"].ToString(),
                        Department =
                        {
                            departmentId = sqlDataReader["DepartmentId"].ToString()
                        }
                    };

                }
            }
            return studentModel;
        }



    }
}
