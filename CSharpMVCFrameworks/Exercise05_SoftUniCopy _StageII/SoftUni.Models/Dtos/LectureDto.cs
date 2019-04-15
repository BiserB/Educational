using System;

namespace SoftUni.Models.Dtos
{
    public class LectureDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int InstanceId { get; set; }
    }
}