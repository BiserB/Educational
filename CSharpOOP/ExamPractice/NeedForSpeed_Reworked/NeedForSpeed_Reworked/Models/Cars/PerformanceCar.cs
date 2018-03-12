using System.Collections.Generic;

public class PerformanceCar : Car
{
    private ICollection<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
                   : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        AddOns = new List<string>();
        Horsepower = (int)(horsepower * 1.5);
        Suspension = (int)(suspension * 0.75);
    }

    public ICollection<string> AddOns
    {
        get { return addOns; }
        set { addOns = value; }
    }

    public override void Upgrade(string extras)
    {
        AddOns.Add(extras);
    }

    public override string ToString()
    {
        string add = "None";
        if (AddOns.Count > 0)
        {
            add = string.Join(", ", AddOns);
        }
        return base.ToString() + "Add-ons: " + add;
    }
}