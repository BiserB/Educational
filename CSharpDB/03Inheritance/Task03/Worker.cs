using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Worker : Human
{
    private double weekSalary;
    private double hoursPerDay;

    public double WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }
    public double HoursPerDay
    {
        get { return this.hoursPerDay; }
        private set
        {
            if ((value < 1) || (value > 12))
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.hoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
    }

    public double SalaryPerHour()
    {
        return this.weekSalary / (this.hoursPerDay * 5);
    }
}
