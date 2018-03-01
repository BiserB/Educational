// Define a class Employee that holds the following information: 
// name, salary, position, department, email and age. 
// The name, salary, position and department are mandatory while the rest are optional.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        List<Employee> register = new List<Employee>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string name = data[0];
            decimal salary = decimal.Parse(data[1]);
            string position = data[2];
            string department = data[3];
            if (data.Length == 4)
            {
                var newEmployee = new Employee(name,salary,position,department);
                register.Add(newEmployee);
            }
            else if (data.Length == 5)
            {
                if (data[4].Contains("@"))
                {
                    string email = data[4];
                    var newEmployee = new Employee(name, salary, position, department, email);
                    register.Add(newEmployee);
                }
                else
                {
                    int age = int.Parse(data[4]);
                    var newEmployee = new Employee(name, salary, position, department, age);
                    register.Add(newEmployee);
                }
            }
            else if(data.Length == 6)
            {
                string email = data[4];
                int age = int.Parse(data[5]);
                var newEmployee = new Employee(name, salary, position, department,email, age);
                register.Add(newEmployee);
            }            
        }
        var highest = register.GroupBy(e => e.Department)
                                       .Select(group => new
                                       {
                                           Dep = group.Key,
                                           Avg = group.Average(e => e.Salary)
                                       })
                                       .OrderByDescending(g => g.Avg)
                                       .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {highest.Dep}");
        
        foreach (var emp in register.Where(e => e.Department == highest.Dep).OrderByDescending(e => e.Salary))
        {
            Console.WriteLine(emp);
        }
        
    }
}
