using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            string townPattern = @"^(?<town>\w+ ?\w*) => (?<count>\d) seats$";
            string studentPattern = @"^(?<student>\w+ ?\w*) *| *(?<mail>\w+@\w+.\w+) *| *(?<date>\d+-\w{3}-\d{4})";
            var townReg = new List<Town>();            
            var groupReg = new List<Group>();
            string input = Console.ReadLine();
            
            while (input != "End")
            {
                if (Regex.IsMatch(input, townPattern))
                {
                    Match data = Regex.Match(input, townPattern);
                    string name = data.Groups["town"].Value;
                    int seats = int.Parse(data.Groups["count"].Value);
                    townReg.Add(new Town { Name = name, Seats = seats, TownStudents = new List<Student>() });
                }                
                else if (Regex.IsMatch(input, studentPattern))
                {
                    string[] data = input.Split('|');
                    string name = data[0].Trim();
                    string mail = data[1].Trim();
                    string date = data[2].Trim();

                    DateTime regDate = DateTime.ParseExact(date, "d-MMM-yyyy", CultureInfo.InvariantCulture);
                    Student next = new Student { Name = name, Mail = mail, RegDate = regDate };
                    townReg.LastOrDefault().TownStudents.Add(next);
                }
                input = Console.ReadLine();
            }
            foreach (var item in townReg)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Seats);
                foreach (var it in item.TownStudents.OrderBy(p => p.Name))
                {
                    Console.WriteLine(it.Name);
                }
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime RegDate { get; set; }
    }
    class Town
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public List<Student> TownStudents { get; set; }
    }
    class Group
    {
        public Town City { get; set; }
        public List<Student> GroupStudents { get; set; }
    }
}
