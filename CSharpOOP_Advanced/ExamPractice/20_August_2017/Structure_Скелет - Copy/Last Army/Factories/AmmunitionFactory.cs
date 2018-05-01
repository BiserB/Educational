
using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type ammoType = assembly.GetTypes()
                           .FirstOrDefault(t => t.Name.Equals(name));

        object[] args = new object[] { name };

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammoType, args);

        return ammunition;
    }
}