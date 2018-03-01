
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
        set { length = value; }
    }
    private decimal Width
    {
        get { return width; }
        set { width = value; }
    }
    private decimal Height
    {
        get { return height; }
        set { height = value; }
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

}