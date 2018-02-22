using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Product
{
    private string name;
    private double price;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price cannot be zero or negative");
            }
            this.price = value;
        }
    }

    public Product(string prName, double prPrice)
    {
        this.Name = prName;
        this.Price = prPrice;
    }
}


