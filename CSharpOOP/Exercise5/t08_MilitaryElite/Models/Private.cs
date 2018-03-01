
public class Private : ISoldier, IPrivate
{
    private int id;
    private string firstName;
    private string lastName;
    private decimal salary;

    public Private(int id, string firstName, string lastName, decimal salary)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}
