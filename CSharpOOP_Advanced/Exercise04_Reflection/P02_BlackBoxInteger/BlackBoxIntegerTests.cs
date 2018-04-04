namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            string targetName = typeof(BlackBoxInteger).FullName;

            Type targetType = Type.GetType(targetName);

            object target = Activator.CreateInstance(targetType, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split('_');

                string methodName = args[0];
                int value = int.Parse(args[1]);

                var methodInfo = targetType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

                methodInfo.Invoke(target, new object[] { value });

                var innerValueInfo = targetType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                var innerValue = innerValueInfo.GetValue(target);

                Console.WriteLine(innerValue);

                input = Console.ReadLine();
            }
        }
    }
}