using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Leg
    {
        public int EnergyConsumption { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public override string ToString()
        {
            string result = String.Empty;
            result += "#Leg:\n\r";
            result += string.Format($"###Energy consumption: {EnergyConsumption}\n\r");
            result += string.Format($"###Strength: {Strength}\n\r");
            result += string.Format($"###Speed: {Speed}\n\r");
            return result;
        }
    }
}
