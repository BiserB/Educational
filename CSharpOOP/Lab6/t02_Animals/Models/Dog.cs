
using System;

public class Dog : Animal
{
    private readonly string sound = "DJAAF";

    public Dog(string name, string favoriteFood) : base(name, favoriteFood)
    { }

    public override string ExplainSelf()
    {
        return base.ExplainSelf() + Environment.NewLine + sound;
    }
}
