using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int num = int.Parse(Console.ReadLine());
        Family fam = new Family();
        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            int age = int.Parse(input[1]);
            Person member = new Person(name, age);
            fam.AddMember(member);
        }
        Console.Write(fam.GetOldestMember().Name + " ");
        Console.WriteLine(fam.GetOldestMember().Age);
    }
}
