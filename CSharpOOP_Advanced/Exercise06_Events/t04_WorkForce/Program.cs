using System;
using System.Collections.Generic;
using System.Linq;
using t04_WorkForce.Contracts;
using t04_WorkForce.Models;

namespace t04_WorkForce
{
    public class Program
    {
        static void Main()
        {
            List<IJob> jobs = new List<IJob>();
            List<IEmployee> employees = new List<IEmployee>();

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "StandardEmployee":
                        StandardEmployee se = new StandardEmployee(tokens[1]);
                        employees.Add(se);
                        break;

                    case "PartTimeEmployee":
                        PartTimeEmployee pte = new PartTimeEmployee(tokens[1]);
                        employees.Add(pte);
                        break;

                    case "Job":
                        string jobName = tokens[1];
                        double jobHours = double.Parse(tokens[2]);
                        IEmployee emp = employees.First(e => e.Name == tokens[3]);
                        Job job = new Job(jobName, jobHours, emp);
                        jobs.Add(job);
                        break;

                    case "Pass":
                        foreach (var j in jobs.Where(w => w.HoursReqired > 0))
                        {
                            j.Update();
                        }
                        break;
                    case "Status":
                        foreach (var j in jobs.Where(w => w.HoursReqired > 0))
                        {
                            Console.WriteLine(j.ToString());
                        }
                        break;
                }
            }
        }
    }
}
