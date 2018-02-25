using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] studentData = Console.ReadLine().Split(' ');
            string[] workerData = Console.ReadLine().Split(' ');

            string stFirstName = studentData[0];
            string stLastName = studentData[1];
            string facultyNumber = studentData[2];
            Student stud = new Student(stFirstName, stLastName, facultyNumber);

            string wFirstName = workerData[0];
            string wLastName = workerData[1];
            double weekSalary = double.Parse(workerData[2]);
            double hoursPerDay = double.Parse(workerData[3]);
            Worker w = new Worker(wFirstName, wLastName, weekSalary, hoursPerDay);

            object N = Environment.NewLine;

            Console.WriteLine($"First Name: {stud.FirstName}" + N +
                               $"Last Name: {stud.LastName}" + N +
                               $"Faculty number: {stud.FacultyNumber}" + N);

            Console.WriteLine($"First Name: {w.FirstName}" + N +
                              $"Last Name: {w.LastName}" + N +
                              $"Week Salary: {w.WeekSalary:f2}" + N +
                              $"Hours per day: {w.HoursPerDay:f2}" + N +
                              $"Salary per hour: {w.SalaryPerHour():f2}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
       
    }
}
