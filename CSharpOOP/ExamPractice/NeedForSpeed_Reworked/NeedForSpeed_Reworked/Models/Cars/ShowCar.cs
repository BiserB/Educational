public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
                   : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        Stars = 0;
    }

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public override void Upgrade(string extras)
    {
        int points = int.Parse(extras);
        Stars += points;
    }

    public override string ToString()
    {
        return base.ToString() + $"{Stars} *";
    }
}