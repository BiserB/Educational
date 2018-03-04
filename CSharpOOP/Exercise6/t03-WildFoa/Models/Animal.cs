
public abstract class Animal
{
    // string Name, double Weight, int FoodEaten

    private string name;
    private double weight;
    private int foodEaten; 

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract bool Eat(Food food);

    public abstract void ProduceSound();
}
