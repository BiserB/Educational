using System.Collections.Generic;

namespace SoftUni.Common
{
    public class EditLectureBindingModel
    {
        public LectureBindingModel Lecture { get; set; }

        public List<InfoViewModel> Resources { get; set; }
    }
}