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

}
