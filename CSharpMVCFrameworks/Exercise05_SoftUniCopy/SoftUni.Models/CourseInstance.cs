using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni.Models
{
    public class CourseInstance
    {
        public CourseInstance()
        {
            this.Students = new List<UserCourse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LecturerId { get; set; }

        public User Lecturer { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<UserCourse> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
