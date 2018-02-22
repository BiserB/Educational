using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private double money;
    private List<Product> bag;

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
    public double Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public  List<Product> Bag { get; set; }

    public void AddToBag(Product article)
    {
        if (this.Money < article.Price)
        {
            Console.WriteLine($"{this.Name} can't afford {article.Name}");
        }
        else
        {
            this.Bag.Add(article);
            this.Money -= article.Price;
            Console.WriteLine($"{this.Name} bought {article.Name}");
        }
        
    }
}
