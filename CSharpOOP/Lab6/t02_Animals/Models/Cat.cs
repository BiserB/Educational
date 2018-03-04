
using System;

public class Cat : Animal
{
    private readonly string sound = "MEEOW";

    public Cat(string name, string favoriteFood) : base(name, favoriteFood)
    { } 

    public override string ExplainSelf()
    {
        return base.ExplainSelf() + Environment.NewLine + sound;
    }
}