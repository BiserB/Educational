using System;

public class Child : Person
{
    private readonly int CHILD_MAX_AGE = 15;

    public Child(string name, int age) : base(name, age)
    { }

    public override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value > CHILD_MAX_AGE)
            {
                throw new ArgumentException($"Child's age must be less than {CHILD_MAX_AGE}!");
            }

            base.Age = value;
        }
    }

    
}
