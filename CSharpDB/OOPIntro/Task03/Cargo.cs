using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Cargo
{
    public string Type { get; set; }
    public int Weight { get; set; }
    public Cargo(int weight, string type)
    {
        this.Type = type;
        this.Weight = weight;
    }
}
