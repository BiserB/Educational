
using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type missionType = assembly.GetTypes()
                           .FirstOrDefault(t => t.Name.Equals(difficultyLevel));

        if (missionType == null)
        {
            throw new ArgumentException($"Mission type {difficultyLevel} doesn't exists!");
        }
        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new ArgumentException($"Mission type {difficultyLevel} is not valid!");
        }

        object[] args = new object[] { neededPoints };

        IMission mission = (IMission)Activator.CreateInstance(missionType, args);

        return mission;
    }
}
