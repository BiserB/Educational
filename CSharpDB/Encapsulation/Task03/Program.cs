using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        List<Product> catalog = new List<Product>();
        List<Person> register = new List<Person>();
        try
        {
            string[] personData = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productData = Console.ReadLine().Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);

            int personCount = personData.Length;
            int productCount = productData.Length;

            for (int i = 0; i < personCount; i++)
            {
                string[] data = personData[i].Split('=');
                string name = data[0];
                double money = double.Parse(data[1]);
                var newPerson = new Person(name, money);
                register.Add(newPerson);
            }

            for (int i = 0; i < productCount; i++)
            {
                string[] data = productData[i].Split('=');
                string name = data[0];
                double price = double.Parse(data[1]);
                var newProduct = new Product(name, price);
                catalog.Add(newProduct);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(' ');
                string personName = data[0];
                string article = data[1];
                Person currentPerson = register.Find(p => p.Name == personName);
                Product currentProduct = catalog.Find(p => p.Name == article);
                currentPerson.AddToBag(currentProduct);
                input = Console.ReadLine();
            }

            foreach (Person p in register)
            {
                Console.Write($"{p.Name} - ");
                if (p.Bag.Count() == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", p.Bag.Select(pr => pr.Name)));
                }
               
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        

        
    }

}
