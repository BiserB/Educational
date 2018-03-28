
public class PetFactory
{
    public Pet Create(string name, int age, string kind)
    {
        return new Pet(name, age, kind);
    }
}