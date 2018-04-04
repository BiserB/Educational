using System.Linq;
using System.Reflection;

public class Tracker
{
    public Tracker()
    {
    }

    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance |
                                      BindingFlags.NonPublic |
                                      BindingFlags.Static);
        foreach (var method in methods)
        {

            foreach (SoftUniAttribute attr in method.GetCustomAttributes<SoftUniAttribute>())
            {
                System.Console.WriteLine($"{method.Name} is writen by {attr.Name}");
            }
        }

    }
}