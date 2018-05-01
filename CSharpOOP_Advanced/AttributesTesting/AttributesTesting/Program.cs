using System;
using System.Reflection;

namespace AttributesTesting
{
    public class Program
    {
        static void Main()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                Console.WriteLine("  -Attributes:");
                foreach (var attr in type.GetCustomAttributes())
                {
                    Console.WriteLine(attr.GetType().Name);
                }
                Console.WriteLine();
            }

        }

    }

    [TestAttribute]
    class MyTestSuite
    {

    }

    class TestAttribute : Attribute
    {

    }
}
