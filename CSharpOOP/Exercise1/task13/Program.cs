using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        string wanted = Console.ReadLine();
        List<Person> family = new List<Person>();

        string input = "";
        int number = 0;
        while ((input = Console.ReadLine()) != "End")
        {
            if (input.Contains("-"))
            {
                string[] data = input.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string parentData = data[0];
                string childData = data[1];
                var parent = family.FirstOrDefault(p => p.Name == parentData || p.Date == parentData);
                var child = family.FirstOrDefault(p => p.Name == childData || p.Date == childData);
                if (parent == null)
                {
                    if (char.IsLetter(parentData[0]))
                    {
                        parent = new Person(number,parentData, "");                        
                    }
                    else
                    {
                        parent = new Person(number,"", parentData);                        
                    }
                    number++;
                    family.Add(parent);
                }
                if (child == null)
                {
                    if (char.IsLetter(childData[0]))
                    {
                        child = new Person(number,childData, "");                        
                    }
                    else
                    {
                        child = new Person(number,"", childData);
                    }
                    number++;
                    family.Add(child);
                }
                parent.Children.Add(child);
                child.Parents.Add(parent);
            }
            else
            {
                string[] data = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0] + " " + data[1];
                string date = data[2];
                
                var personByName = family.FirstOrDefault(p => p.Name == name);
                var personByDate = family.FirstOrDefault(p => p.Date == date);
                var person = family.FirstOrDefault(p => p.Name == name || p.Date == date);
                person.Name = name;
                person.Date = date;
                if (personByName != null && personByDate != null)
                {
                    int nameIndex = family.IndexOf(personByName);
                    int dateIndex = family.IndexOf(personByDate);
                    if (nameIndex != dateIndex)
                    {
                        if (nameIndex < dateIndex)
                        {
                            foreach (var item in personByDate.Parents)
                            {
                                if (!personByName.Parents.Contains(item) )
                                {
                                    personByName.Parents.Add(item);
                                }
                            }
                            personByName.Parents.OrderBy(p => p.Number);
                            foreach (var item in personByDate.Children)
                            {
                                if (!personByName.Children.Contains(item))
                                {
                                    personByName.Children.Add(item);
                                }
                            }
                            personByName.Children.OrderBy(p => p.Number);
                        }
                        else
                        {
                            foreach (var item in personByName.Parents)
                            {
                                if (!personByDate.Parents.Contains(item))
                                {
                                    personByDate.Parents.Add(item);
                                }
                            }
                            personByDate.Parents.OrderBy(p => p.Number);
                            foreach (var item in personByName.Children)
                            {
                                if (!personByDate.Children.Contains(item))
                                {
                                    personByDate.Children.Add(item);
                                }
                            }
                            personByDate.Children.OrderBy(p => p.Number);
                        }
                    }
                }
                
                
            }
            
        }
        var first = family.FirstOrDefault(p => p.Name == wanted || p.Date == wanted);
        
        Console.WriteLine($"{first.Name} {first.Date}");
        Console.WriteLine("Parents:");
        foreach (var parent in first.Parents)
        {
            Console.WriteLine($"{parent.Name} {parent.Date}");
        }
        Console.WriteLine("Children:");
        foreach (var child in first.Children)
        {
            Console.WriteLine($"{child.Name} {child.Date}");
        }
    }
}