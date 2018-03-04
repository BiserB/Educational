
public abstract class Mammal: Animal
{
    private string livingRegion;

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override abstract bool Eat(Food food);

    public override abstract void ProduceSound();
   
}
