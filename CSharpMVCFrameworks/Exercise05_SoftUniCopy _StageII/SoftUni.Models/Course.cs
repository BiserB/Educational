using System.Collections.Generic;

namespace SoftUni.Models
{
    public class Course
    {
        public Course()
        {
            this.Instances = new List<CourseInstance>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CourseInstance> Instances { get; set; }
    }
}