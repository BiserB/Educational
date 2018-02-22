using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box
{   //length, width and height.
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double CalcSurface()
    {
        double result = (2 * this.Length * this.Width)
                    + (2 * this.Width * this.Height)
                    + (2 * this.Length * this.Height);
        return result;
    }
    public double CalcLateralSurface()
    {
        double result = (2 * this.Width * this.Height)
                      + (2 * this.Length * this.Height);
        return result;
    }
    public double CalcVolume()
    {
        double result = this.Width * this.Height * this.Length;
        return result;
    }
}

