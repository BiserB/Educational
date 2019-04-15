namespace SoftUni.Models
{
    public class Resource
    {
        public Resource()
        {
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public int ResourceTypeId { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Title { get; set; }

        public string ResourceUrl { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public bool IsDeleted { get; set; }
    }
}