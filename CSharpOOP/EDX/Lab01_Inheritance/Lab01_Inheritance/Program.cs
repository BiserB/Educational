using Lab01_Inheritance.Models;
using System;

namespace Lab01_Inheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instantiates Employee Object with name Libby and salary 2000 called emp1
            var emp1 = new Employee("Libby", 2000);
            // Instantiates TechnicalEmployee Object with name Zaynah called emp2
            var emp2 = new TechnicalEmployee("Zaynah");
            // Instantiates BusinessEmployee Object with name Winter called emp3
            var emp3 = new BusinessEmployee("Winter");

            // Output to the console window
            Console.WriteLine(emp1.employeeStatus());
            Console.WriteLine(emp2.employeeStatus());
            Console.WriteLine(emp3.employeeStatus());

            TechnicalEmployee te = new TechnicalEmployee("Zet");
            Employee e = te;
            Console.WriteLine(e.employeeStatus());
        }
    }
}
