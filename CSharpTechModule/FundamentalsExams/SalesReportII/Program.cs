using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportII
{
    class Program
    {
        static void Main(string[] args)
        {
            var sales = new Dictionary<string, List<Sale>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                Sale newSale = Sale.NewSale(input);
                string town = newSale.Town;
                if (!sales.ContainsKey(town))
                {
                    sales[town] = new List<Sale>();
                }
                sales[town].Add(newSale);
            }
            foreach (var item in sales.OrderBy(p => p.Key))
            {
                double total = 0.0;
                foreach (var entry in item.Value)
                {
                    total += (entry.Qty * entry.Price);
                }
                Console.WriteLine("{0} -> {1:0.00}", item.Key, total);
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
