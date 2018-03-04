
using System;

public class Circle : Shape
{
    private const double pi = Math.PI;
    private double radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public override double CalculateArea()
    {
        return pi * radius * radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * pi * radius;
    }

    public virtual string Draw()
    {
        return base.Draw() + "Circle";
    }
}