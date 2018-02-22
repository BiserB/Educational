using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Dough
{
    private double modifier = 1;
    private double calPerGram = 2;
    private string flourType;
    private string bakingTech;
    private int weight;

    private string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (value != "White" && value != "Wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }
    private string BakingTech
    {
        get { return this.bakingTech; }
        set
        {
            if (value != "Crispy" && value != "Chewy" && value != "Homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTech = value;
        }
    }
    private int Weigth
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double CalPerGram
    {
        get { return this.calPerGram * weight; }
        private set
        {
            switch (this.FlourType)
            {
                case "White": modifier *= 1.5; break;
            }
            switch (this.BakingTech)
            {
                case "Crispy": modifier *= 0.9; break;
                case "Chewy": modifier *= 1.1; break;
                case "Homemade": modifier *= 1.0; break;
            }
            this.calPerGram *= modifier;
        }
    }

    public Dough(string flourType, string bakingTech, int weigth)
    {
        this.FlourType = flourType;
        this.BakingTech = bakingTech;
        this.Weigth = weigth;
        this.CalPerGram = calPerGram;
    }

}
