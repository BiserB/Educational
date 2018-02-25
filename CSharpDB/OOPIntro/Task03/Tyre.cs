using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tyre
{
    public double Presure { get; set; }
    public int Age { get; set; }
    public Tyre(double presure, int age)
    {
        this.Presure = presure;
        this.Age = age;
    }
}