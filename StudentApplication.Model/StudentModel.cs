﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Model
{
    public class StudentModel
    {
        public string studentID { get; set; }

        public string studentName { get; set; }

        public string studentEmail { get; set; }

        public string studentGender { get; set; }

        public string dateofBirth { get; set; }

        public string studentCity { get; set; }

        public DepartmentModel Department { get; set; }

    }
}