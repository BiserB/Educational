
public class Rebel : IBuyer
{
    private string group;
    private int food;
    private string name;
    private int age;    

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }
    public int Food
    {
        get { return food; }
        set { food = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }    

    public void BuyFood()
    {
        Food += 5;
    }
}
