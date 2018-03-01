
using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : Private, IEngineer
{
    private Corps corps;
    private List<IRepair> repairs;

    public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
        : base(id, firstName, lastName, salary)
    {
        Corps = corps;
        Repairs = new List<IRepair>();
    }

    public Corps Corps
    {
        get { return corps; }
        set { corps = value; }
    }
    public List<IRepair> Repairs
    {
        get { return repairs; }
        set { repairs = value; }
    }

    public void AddRepair(Repair repair)
    {
        Repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine( $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
        sb.AppendLine( $"Corps: {Corps}");
        sb.AppendLine("Repairs:");
        foreach (var r in Repairs)
        {
            sb.AppendLine("  " + r.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
