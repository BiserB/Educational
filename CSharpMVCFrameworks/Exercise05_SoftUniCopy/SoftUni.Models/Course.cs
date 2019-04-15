using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CourseInstance> Instances { get; set; }
    }
}
