using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    public Rectangle(string id, double width, double height, double x, double y)
    {
        Id = id;
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public bool Intersect(Rectangle second)
    {        
        if (this.X > second.X + second.Width || second.X > this.X + this.Width)
        {
            return false;
        }
        if (this.Y < second.Y - second.Height || second.Y < this.Y - this.Height)
        {
            return false;
        }
        return true;
    }
}
