using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Car
{   //model, engine, cargo and a collection of exactly 4 tires. 
    private string model;
    private Engine carEngine;
    private Tyre[] tyres;
    private Cargo carCargo;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Engine CarEngine
    {
        get { return this.carEngine; }
        set { this.carEngine = value; }
    }    
    public Tyre[] CarTyres
    {
        get { return this.tyres; }
        set { this.tyres = value; }
    }
    public Cargo CarCargo
    {
        get { return this.carCargo; }
        set { this.carCargo = value; }
    }
    
    public Car()
    {
        this.tyres = new Tyre[4];
    }
    public Car(string model,Engine engine, Tyre[] tyres, Cargo cargo)
        : this()
    {
        this.Model = model;
        this.CarEngine = engine;
        this.CarTyres = tyres;
        this.CarCargo = cargo;
    }


}
