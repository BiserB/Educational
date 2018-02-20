using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sale> sales = new List<Sale>();
            var result = new Dictionary<string, double>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                Sale newSale = Sale.NewSale(input);
                sales.Add(newSale);
            }

            foreach (Sale item in sales)
            {
                string town = item.Town;
                double total = item.Qty * item.Price;
                if (!result.ContainsKey(town))
                {
                    result[town] = 0;
                }
                result[town] += total;
            }
            foreach (var item in result.OrderBy(p => p.Key))
            {
                Console.WriteLine("{0} -> {1:0.00}", item.Key , item.Value);
            }

            
        }
    }
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        

        public static Sale NewSale(string input)
        {
            string[] data = input.Split(' ');
            string town = data[0];
            string product = data[1];
            double price = double.Parse(data[2]);
            double qty = double.Parse(data[3]);
            return new Sale
            {
                Town = town,
                Product = product,
                Price = price,
                Qty = qty
            };
        }
    }
}
