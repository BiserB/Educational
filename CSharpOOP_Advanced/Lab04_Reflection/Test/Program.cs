using System;
using System.Reflection;

namespace Test
{
    public class Program
    {
        static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: {0} BaseType: {1}", type, type.BaseType);

                var properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    Console.WriteLine($" - Prop: {prop.Name.PadLeft(20)};   Prop. Type: {prop.GetType()}");
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine($" - Field: {field.Name.PadLeft(19)};   field Type {field.GetType()}");
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine($" - Method: {method.Name};    ");
                }
            }


            var user = new { Name = "testUser", Pass = "123" };
        }
    }

    public class Employee
    {
        private int id;
        private string name = "empty";

        public Employee(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public static Type BaseType { get; internal set; }

        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }

    public class Engineer : Employee
    {
        public string spec;

        public Engineer(int id, string name, string specialty) : base(id, name)
        {
            Specialty = specialty;
        }

        public string Specialty { get; set; }
    }
}
