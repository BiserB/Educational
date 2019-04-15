using System.Collections.Generic;

namespace SoftUni.Common
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            this.Instances = new List<InstanceViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<InstanceViewModel> Instances { get; set; }

        public int InstanceCount { get; set; }
    }
}