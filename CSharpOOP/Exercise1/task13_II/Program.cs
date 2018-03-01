using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        string wanted = Console.ReadLine();
        List<Person> family = new List<Person>();
        List<string> relativeData = new List<string>();
        Dictionary<string, string> personalData = new Dictionary<string, string>();

        string input = "";

        while ((input = Console.ReadLine()) != "End")
        {
            if (input.Contains("-"))
            {
                relativeData.Add(input);
            }
            else
            {
                string[] data = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0] + " " + data[1];
                string date = data[2];
                personalData[name] = date;
            }
        }
        foreach (string line in relativeData)
        {
            string[] data = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            string parentData = data[0];
            string parentName = "";
            string parentDate = "";
            string childData = data[1];
            string childName = "";
            string childDate = "";

            foreach (var row in personalData)
            {
                if (parentData == row.Key || parentData == row.Value)
                {
                    parentName = row.Key;
                    parentDate = row.Value;
                }                
                else if (childData == row.Key || childData == row.Value)
                {
                    childName = row.Key;
                    childDate = row.Value;
                }
            }
            var parent = family.FirstOrDefault(p => p.Name == parentName);
            var child = family.FirstOrDefault(p => p.Name == childData);
            if (parent == null)
            {
                parent = new Person(parentName, parentDate);
                family.Add(parent);
            }
            if (child == null)
            {
                child = new Person(childName, childDate);
                family.Add(child);
            }             
            parent.Children.Add(child);
            child.Parents.Add(parent);           
            
        }

        var member = family.FirstOrDefault(p => p.Name == wanted || p.Date == wanted);
        Console.WriteLine($"{member.Name} {member.Date}");
        Console.WriteLine("Parents:");
        member.Parents.ForEach(m => Console.WriteLine(m));
        Console.WriteLine("Children:");
        member.Children.ForEach(m => Console.WriteLine(m));
    }
}