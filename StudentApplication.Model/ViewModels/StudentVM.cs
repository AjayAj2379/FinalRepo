using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class StudentVM
    {
        public string studentID { get; set; }

        public string depatmentID { get; set; }

        public string studentName { get; set; }

        public string studentEmail { get; set; }

        public string studentGender { get; set; }

        public string dateofBirth { get; set; }

        public string departmentName { get; set; }
    }
}