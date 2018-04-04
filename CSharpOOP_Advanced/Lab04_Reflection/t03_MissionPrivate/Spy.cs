using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{  
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type targetType = Type.GetType(className);

        var privateMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {className}");

        sb.AppendLine($"Base Class: {targetType.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();

    }
}
