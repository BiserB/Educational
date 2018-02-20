using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Arm
    {
        public int EnergyConsumption { get; set; }
        public int ArmDistance { get; set; }
        public int FingersCount { get; set; }
        public override string ToString()
        {
            string result = String.Empty;
            result += "#Arm:\n\r";
            result += string.Format($"###Energy consumption: {EnergyConsumption}\n\r");
            result += string.Format($"###Reach: {ArmDistance}\n\r");
            result += string.Format($"###Fingers: {FingersCount}\n\r");
            return result;
        }
    }
}
