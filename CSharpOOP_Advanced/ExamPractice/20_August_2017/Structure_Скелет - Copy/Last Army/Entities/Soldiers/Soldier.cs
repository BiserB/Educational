using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; }

    public double Endurance
    {
        get { return endurance; }
        protected set
        {
            endurance = Math.Min(value, 100);
        }
    }

    public virtual double OverallSkill => this.Age * this.Experience;

    public IDictionary<string, IAmmunition> Weapons { get; }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        int invalidWeapons = this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0);

        return invalidWeapons == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {

        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }



    public abstract void Regenerate();

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}