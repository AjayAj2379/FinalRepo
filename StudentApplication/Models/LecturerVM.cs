﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class LecturerVM
    {
        public string lecturerId { get; set; }
        public string lecturerName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string departmentName { get; set; }
        public string departmentId { get; set; }
    }
}