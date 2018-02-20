using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Head
    {
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string Skin { get; set; }
        public override string ToString()
        {
            string result = String.Empty;
            result += "#Head:\n\r";
            result += string.Format($"###Energy consumption: {EnergyConsumption}\n\r");
            result += string.Format($"###IQ: {IQ}\n\r");
            result += string.Format($"###Skin material: {Skin}\n\r");
            return result;
        }
    }
}
