using System.Collections.Generic;

namespace SoftUni.Common
{
    public class TrainerPanelViewModel
    {
        public List<CourseViewModel> Courses { get; set; }

        public List<string> Instances { get; set; }

        public List<string> Resources { get; set; }
    }
}