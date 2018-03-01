using System;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<string, Student> Repo = new Dictionary<string, Student>();

    static void Main()
    {       
        while (true)
        {
            ParseCommand();
        }
    }

    public static void ParseCommand()
    {
        string[] args = Console.ReadLine().Split();

        if (args[0] == "Create")
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            if (!Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }
        else if (args[0] == "Show")
        {
            var name = args[1];
            Print(name);
            
        }
        else if (args[0] == "Exit")
        {
            Environment.Exit(0);
        }
    }

    public static void Print(string name)
    {        
        if (Repo.ContainsKey(name))
        {
            var student = Repo[name];
            Console.Write(student);

            if (student.Grade >= 5.00)
            {
                Console.WriteLine(" Excellent student.");
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                Console.WriteLine(" Average student.");
            }
            else
            {
                Console.WriteLine(" Very nice person.");
            }
        }
    }
}
