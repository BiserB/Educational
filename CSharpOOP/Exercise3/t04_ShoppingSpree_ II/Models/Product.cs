using System;

namespace t04_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal money)
        {
            Name = name;
            Cost = money;
        }        

        public string  Name
        {
            get { return name; }
            set { name = value; }
        }  
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
    }
}