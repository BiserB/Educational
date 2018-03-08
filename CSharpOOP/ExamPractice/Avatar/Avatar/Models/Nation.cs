using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        benders = new List<Bender>();
        monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        benders.Add(bender);
    }

    internal void AddMonument(Monument monument)
    {
        monuments.Add(monument);
    }

    public double TotalPower()
    {
        int multiplier = monuments.Sum(m => m.GetAffinity()) / 100;
        double bendersPower = benders.Sum(b => b.GetPower());
        return bendersPower + bendersPower * multiplier;
    }

    public void DeclareDefeat()
    {
        benders.Clear();
        monuments.Clear();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Benders:");
        if (benders.Count > 0)
        {
            sb.AppendLine();
            foreach (var bender in benders)
            {
                sb.Append("###");
                sb.AppendLine(bender.ToString());
            }
        }
        else
        {
            sb.AppendLine(" None");
        }

        sb.Append("Monuments:");
        if (monuments.Count > 0)
        {
            sb.AppendLine();
            foreach (var monument in monuments)
            {
                sb.Append("###");
                sb.AppendLine(monument.ToString());
            }
        }
        else
        {
            sb.Append(" None");
        }

        return sb.ToString().Trim();
    }
}