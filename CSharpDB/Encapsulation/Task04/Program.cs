using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] initPizza = Console.ReadLine().Split(' ');
            string pizzaName = initPizza[1];
            string[] initDough = Console.ReadLine().Split(' ');
            string doughFlour = initDough[1];
            string doughType = initDough[2];
            int doughWeight = int.Parse(initDough[3]);

            Pizza mmm = new Pizza(pizzaName, new Dough(doughFlour, doughType, doughWeight));

            string newTopping = Console.ReadLine();
            while (newTopping != "END")
            {
                string[] data = newTopping.Split(' ');
                string toppingType = data[1];
                int toppingWeight = int.Parse(data[2]);
                mmm.AddTopping(new Topping(toppingType, toppingWeight));
                newTopping = Console.ReadLine();
            }

            
            
            Console.Write(mmm.Name);
            Console.WriteLine(" - {0:f2} Calories.", mmm.CalTotal());           

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        
    } 
}

