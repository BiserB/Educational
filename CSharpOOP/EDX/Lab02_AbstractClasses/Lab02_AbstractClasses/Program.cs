using Lab01_Inheritance.Models;
using System;

namespace Lab02_AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            TechnicalEmployee techEmployee = new TechnicalEmployee("Pesho");
            Console.WriteLine(techEmployee.employeeStatus());
        }
    }
}
