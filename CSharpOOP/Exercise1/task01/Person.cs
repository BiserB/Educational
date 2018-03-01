


public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }    

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person() : this(1,"No name")
    {}
    public Person(int age) : this(age, "No name")
    {}
    public Person(int age, string name)
    {
        this.Name = name;
        this.Age = age;
    }
}

