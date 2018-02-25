using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();

        DateModifier DM = new DateModifier(date1, date2);
        Console.WriteLine(DM.CalculateDiff());
    }

}
