using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SoftUni.Common
{
    public class ResourceBindingModel
    {
        public int ResourceId { get; set; }

        public int ResourceTypeId { get; set; }

        public string Title { get; set; }

        public string ResourceUrl { get; set; }

        public int LectureId { get; set; }

        public List<SelectListItem> ResourceTypes { get; set; }
    }
}