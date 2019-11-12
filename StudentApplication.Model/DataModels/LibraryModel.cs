using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Model
{
   public class LibraryModel
    {
        public string courseId { get; set; }
        public string authorName { get; set; }
        public int rackNumber { get; set; }
        public long yearOfPublishing { get; set; }
    }
}
