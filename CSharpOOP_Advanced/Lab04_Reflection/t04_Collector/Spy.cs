using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{  
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type targetType = Type.GetType(className);

        var methods = targetType.GetMethods(BindingFlags.Instance | 
                                            BindingFlags.NonPublic |
                                            BindingFlags.Public);
        

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();

    }
}
