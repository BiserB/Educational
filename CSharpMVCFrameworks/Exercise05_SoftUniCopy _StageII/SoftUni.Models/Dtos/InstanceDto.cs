using System;

namespace SoftUni.Models.Dtos
{
    public class InstanceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }
    }
}