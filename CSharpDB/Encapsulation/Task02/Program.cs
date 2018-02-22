using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double l = double.Parse(Console.ReadLine());
        double w = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        try
        {
            Box newBox = new Box(l, w, h);

            Console.WriteLine("Surface Area - {0:f2}", newBox.CalcSurface());
            Console.WriteLine("Lateral Surface Area - {0:f2}", newBox.CalcLateralSurface());
            Console.WriteLine("Volume - {0:f2}", newBox.CalcVolume());
        }
        catch (Exception  E)
        {
            Console.WriteLine(E.Message);
        }
        
    }
}

