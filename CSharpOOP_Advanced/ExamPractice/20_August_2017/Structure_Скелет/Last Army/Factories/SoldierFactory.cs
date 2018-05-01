using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldiersFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type soldierType = assembly.GetTypes()
                           .FirstOrDefault(t => t.Name.Equals(soldierTypeName));

        if (soldierType == null)
        {
            throw new ArgumentException($"Soldier type {soldierTypeName} doesn't exists!");
        }
        if (!typeof(IMission).IsAssignableFrom(soldierType))
        {
            throw new ArgumentException($"Mission type {soldierTypeName} is not valid!");
        }

        object[] args = new object[] { name, age, experience, endurance };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, args);

        return soldier;
    }
}