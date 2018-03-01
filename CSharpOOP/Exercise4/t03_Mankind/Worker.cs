
using System;

public class Worker: Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;
    private decimal salaryPerHour;  

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }
    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }
    public decimal SalaryPerHour
    {
        get { return WeekSalary / 5 / WorkHoursPerDay; }        
    }

    public override string ToString()
    {
        string result = $"First Name: {this.FirstName}" + Environment.NewLine;
        result += $"Last Name: {this.LastName}" + Environment.NewLine;
        result += $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine;
        result += $"Hours per day: {this.WorkHoursPerDay:f2}" + Environment.NewLine;
        result += $"Salary per hour: {this.SalaryPerHour:f2}" + Environment.NewLine;
        return result;
    }

}