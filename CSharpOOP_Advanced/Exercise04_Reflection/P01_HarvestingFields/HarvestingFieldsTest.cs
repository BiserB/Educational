namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string targetName = typeof(HarvestingFields).FullName;

            Type targetType = Type.GetType(targetName);

            var allFields = targetType.GetFields(BindingFlags.Instance |
                                                 BindingFlags.NonPublic |
                                                 BindingFlags.Public |
                                                 BindingFlags.Static);
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            while (input != "HARVEST")
            {
                sb.Clear();

                foreach (var field in allFields)
                {
                    string modifier = field.Attributes.ToString().ToLower();

                    if (modifier == "family")
                    {
                        modifier = "protected";
                    }

                    if (input == "all" || input == modifier)
                    {
                        sb.AppendLine($"{modifier} {field.FieldType.Name} {field.Name}");
                    }
                }

                Console.WriteLine(sb.ToString().Trim());

                input = Console.ReadLine();
            }
        }
    }
}