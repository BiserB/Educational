
using System;
using t04_WorkForce.Contracts;

namespace t04_WorkForce.Models
{
    public class Job : IJob
    {
        public Job(string name, double hoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.HoursReqired = hoursRequired;
            this.Employee = employee;
        }

        public string Name { get; }

        public double HoursReqired { get; private set; }

        public IEmployee Employee { get; }

        public void Update()
        {
            HoursReqired -= Employee.Hours;
            if (HoursReqired <= 0)
            {
                OnJobEnded();
            }
        }

        protected virtual void OnJobEnded()
        {
            Console.WriteLine($"Job {this.Name} done!");
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursReqired}";
        }
    }
}
