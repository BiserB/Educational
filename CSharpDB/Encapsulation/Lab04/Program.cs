
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Team newTeam = new Team();

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string firstName = data[0];
                string secondName = data[1];
                int age = int.Parse(data[2]);
                double salary = double.Parse(data[2]);

                Person player = new Person(firstName, secondName, age, salary);
                newTeam.AddPlayer(player);
            }          
                       
            
            int count1 = newTeam.FirstTeam.Count();
            Console.WriteLine($"First team have {count1} players");
            
            //foreach (var pl in newTeam.FirstTeam)
            //{
            //    Console.WriteLine(pl.FirstName + pl.SecondName);
            //}

            int count2 = newTeam.ReserveTeam.Count();
            Console.WriteLine($"Reserve team have {count2} players");
            
            //foreach (var pl in newTeam.ReserveTeam)
            //{
            //    Console.WriteLine(pl.FirstName + pl.SecondName);
            //}


        }
    }
}
