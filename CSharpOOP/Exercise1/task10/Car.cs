using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    
    public Car(string model, Engine selectedEngine, int weight, string color)
    {
        Model = model;
        this.Engine = selectedEngine;
        Weight = weight;
        Color = color;
    }    

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }
}

