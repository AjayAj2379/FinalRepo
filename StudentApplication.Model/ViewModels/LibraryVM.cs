﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Models
{
    public class LibraryVM
    {
        public string courseId { get; set; }
        public string courseName { get; set; }
        public string authorName { get; set; }
        public int rackNumber { get; set; }
        public long yearOfPublishing { get; set; }
    }
}