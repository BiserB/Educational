
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",            
            "Helmet"            
        };

    public Ranker(string Name, int Age, double Experience, double Endurance) 
        : base(Name, Age, Experience, Endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override void Regenerate()
    {
        base.Endurance += this.Age + 10;
    }
}
