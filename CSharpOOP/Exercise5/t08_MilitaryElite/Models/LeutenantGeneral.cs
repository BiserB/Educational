
using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<IPrivate> privates;

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<IPrivate>();
    }

    public List<IPrivate> Privates
    {
        get { return privates; }
        set { privates = value; }
    }

    public void AddPrivate(Private p)
    {
        Privates.Add(p);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");        
        sb.AppendLine("Privates:");
        foreach (var p in Privates)
        {
            sb.AppendLine("  " + p.ToString());
        }
        return sb.ToString().TrimEnd();
    }

}