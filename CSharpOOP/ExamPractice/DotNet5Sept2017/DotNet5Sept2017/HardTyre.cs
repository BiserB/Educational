using System;
using System.Collections.Generic;
using System.Text;


public class HardTyre : Tyre
{
    private decimal grip;

    public HardTyre(string name, decimal hardness, decimal grip)
         : base(name, hardness)
    {
        this.Name = "Hard";
        this.Grip = grip;
    }

    public decimal Grip
    {
        get { return grip; }
        set { grip = value; }
    }
}
