using System;
using System.Collections.Generic;
using System.Text;

namespace t04_ShoppingSpree
{
    // name, money and a bag of products.
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        internal string Name
        {
            get { return name; }
            private set { name = value; }
        }
        internal decimal Money
        {
            get { return money; }
            private set { money = value; }
        }
        internal List<Product> Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
        
        internal void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.Money -= product.Cost;
                Bag.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }   

    }
}
