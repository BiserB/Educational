
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : Private, ICommando
{
    private Corps corps;
    private List<IMission> missions;

    public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
        : base(id, firstName, lastName, salary)
    {
        Corps = corps;
        Missions = new List<IMission>();
    }

    public Corps Corps
    {
        get { return corps; }
        set { corps = value; }
    }
    public List<IMission> Missions
    {
        get { return missions; }
        set { missions = value; }
    }

    public void AddMission(Mission mission)
    {
        Missions.Add(mission);
    }

    public void CompleteMission(Mission mission)
    {
        IMission selected = Missions.FirstOrDefault(m => m.CodeName == mission.CodeName);
        if (selected != null)
        {
            selected.State = State.Finished;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
        sb.AppendLine($"Corps: {Corps}");
        sb.AppendLine("Missions:");
        foreach (var m in Missions)
        {
            sb.AppendLine("  " + m.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
