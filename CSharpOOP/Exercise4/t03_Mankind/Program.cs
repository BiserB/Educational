using System;


public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] data = Console.ReadLine().Split();            
            Student student = new Student(data[0], data[1], data[2]);
            

            data = Console.ReadLine().Split();
            decimal weekSalary = decimal.Parse(data[2]);
            decimal workHoursPerDay = decimal.Parse(data[3]);
            Worker worker = new Worker(data[0], data[1], weekSalary, workHoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);

        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        
        
    }
}
