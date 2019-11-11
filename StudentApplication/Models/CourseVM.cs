using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class CourseVM
    {
        public string courseId { get; set; }
        public string courseName { get; set; }
        public string lecturerId { get; set; }
        public string semesterName { get; set; }
        public string depatmentId { get; set; }
    }
}