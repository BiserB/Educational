// A box’s side should not be zero or a negative number.


using System;

internal class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    private decimal Length
    {
        get { return length; }
        set
        {
            if (value <= 0) { WrongParameter("Length"); }        
            length = value;
        }
    }
    private decimal Width
    {
        get { return width; }
        set
        {
            if (value <= 0) { WrongParameter("Width"); }
            width = value;
        }
    }
    private decimal Height
    {
        get { return height; }
        set
        {
            if (value <= 0) { WrongParameter("Height"); }
            height = value;
        }
    }   

    internal decimal SurfaceArea()
    {
        decimal result = 2 * Length * Width + LateralSurfaceArea();
        return result;
    }
    internal decimal LateralSurfaceArea()
    {
        decimal result = 2 * Length * Height + 2 * Width * Height;
        return result;
    }
    internal decimal Volume()
    {
        decimal result = Length * Height * Width;
        return result;
    }   
     private void WrongParameter(string param)
    {
        throw new ArgumentException($"{param} cannot be zero or negative.");
    }
}