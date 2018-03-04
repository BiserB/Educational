
public abstract class Feline : Mammal
{
    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override abstract void ProduceSound();

    public override string ToString()
    {
        return $"{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}";
    }
}
