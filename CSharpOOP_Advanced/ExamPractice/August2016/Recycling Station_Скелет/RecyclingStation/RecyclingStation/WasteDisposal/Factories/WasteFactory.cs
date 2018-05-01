
using System;
using System.Linq;
using System.Reflection;

public class WasteFactory : IWasteFactory
{
    private const string Suffix = "Garbage";

    public IWaste CreateWaste(string name, double weight, double volumePerKg, string type)
    {
        string nameOfGarbage = type ;

        Assembly assembly = Assembly.GetExecutingAssembly();

        Type wasteType = assembly.GetTypes().FirstOrDefault(t => t.Name == nameOfGarbage);

        object[] args = new object[] { name, weight, volumePerKg};

        IWaste waste = (IWaste)Activator.CreateInstance(wasteType, args);

        return waste;
    }
}
