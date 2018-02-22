using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Topping
{
    private int weight;
    private string toppingType;
    private double modifier = 1;
    private double calPerGram = 2;


    private int Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }
    private string ToppingType
    {
        get { return this.toppingType; }
        set
        {
            if (value != "Meat" && value != "Veggies" && value!= "Cheese" && value != "Sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingType = value;
        }
    }
    public double CalPerGram
    {
        get { return this.calPerGram * weight; }
        private set
        {
            switch (this.ToppingType)
            {
                case "Meat":    modifier = 1.2;   break;
                case "Veggies": modifier = 0.8;   break;
                case "Cheese":  modifier = 1.1;   break;
                case "Sauce":   modifier = 0.9;   break;
            }
            this.calPerGram *= modifier;
        }
    }
    public Topping(string toppingType, int weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
        this.CalPerGram = calPerGram;
    }

}

