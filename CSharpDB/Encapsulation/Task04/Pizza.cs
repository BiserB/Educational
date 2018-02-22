using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pizza
{
    private string name;
    private Dough pizzaDough;
    private List<Topping> toppings;
    public Pizza()
    {
        this.toppings = new List<Topping>();
    }
    public Pizza(string name, Dough pizzaDough)
        : this()
    {
        this.Name = name;
        this.PizzaDough = pizzaDough;
        this.Toppings = toppings;
    }    

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentNullException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    public Dough PizzaDough
    {
        get { return this.pizzaDough; }
        set { this.pizzaDough = value; }
    }
    private List<Topping> Toppings { get; set; }

    public int ToppingCount()
    {
        int count = this.toppings.Count();
        return count;
    }
    public double CalTotal()
    {
        return this.pizzaDough.CalPerGram + this.toppings.Sum(p => p.CalPerGram);
    }
    public void AddTopping(Topping t)
    {
        if (ToppingCount() >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        else
        {
            this.toppings.Add(t);
        }
    }

}

