using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type targetType = Type.GetType(investigatedClass);

        var fields = targetType.GetFields(BindingFlags.Instance |
                                          BindingFlags.Public | 
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static);

        object targetInstance = Activator.CreateInstance(targetType, new object[] { });

        StringBuilder sb = new StringBuilder();

        sb.AppendLine( $"Class under investigation: {investigatedClass}" );

        foreach (var field in fields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(targetInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type targetType = Type.GetType(className);

        FieldInfo[] publicFields = targetType.GetFields(BindingFlags.Instance |
                                                        BindingFlags.Static |
                                                        BindingFlags.Public);

        MethodInfo[] publicMethods = targetType.GetMethods(BindingFlags.Instance |
                                                  BindingFlags.Public);

        MethodInfo[] privateMethods = targetType.GetMethods(BindingFlags.Instance |
                                                    BindingFlags.NonPublic);

        foreach (var field in publicFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        foreach (var method in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        return sb.ToString().Trim();
    }
}
