using System.Collections.Generic;

namespace SoftUni.Common
{
    public class EditInstanceBindingModel
    {
        public InstanceBindingModel Instance { get; set; }

        public List<InfoViewModel> Lectures { get; set; }
    }
}