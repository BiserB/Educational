using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Torso
    {
        public int EnergyConsumption { get; set; }
        public double Procesor { get; set; }
        public string Material { get; set; }
        public override string ToString()
        {
            string result = String.Empty;
            result += "#Torso:\n\r";
            result += string.Format($"###Energy consumption: {EnergyConsumption}\n\r");
            result += string.Format($"###Processor size: {Procesor}\n\r");
            result += string.Format($"###Corpus material: {Material}\n\r");
            return result;
        }
    }
}
