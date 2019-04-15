using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni.Models
{
    public class UserCourse
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int CourseInstanceId { get; set; }

        public CourseInstance CourseInstance { get; set; }
    }
}
