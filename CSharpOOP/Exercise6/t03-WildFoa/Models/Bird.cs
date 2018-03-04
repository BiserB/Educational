
public abstract class Bird : Animal
{
    private double wingSize;

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public override abstract bool Eat(Food food);

    public override abstract void ProduceSound();

    public override string ToString()
    {
        return $"{Name}, {WingSize}, {Weight}, {FoodEaten}"; 
    }
}
