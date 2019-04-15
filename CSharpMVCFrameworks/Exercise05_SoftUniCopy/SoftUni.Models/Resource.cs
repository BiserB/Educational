namespace SoftUni.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public int ResourceTypeId { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Content { get; set; }

        public string ResourceUrl { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }
    }
}