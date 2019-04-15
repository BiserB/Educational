using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public class CourseInstance
    {
        public CourseInstance()
        {
            this.Students = new List<UserCourse>();
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        public User Trainer { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserCourse> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}