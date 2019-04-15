using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public class Lecture
    {
        public Lecture()
        {
            this.Resources = new List<Resource>();
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LectureHall { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int InstanceId { get; set; }

        public CourseInstance Instance { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public bool IsDeleted { get; set; }
    }
}