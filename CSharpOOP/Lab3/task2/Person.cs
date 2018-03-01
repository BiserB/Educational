

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
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

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }

    public void IncreaseSalary(decimal bonus) 
    {
        if (this.Age < 30)
        {
            this.Salary += Salary * (bonus / 200);
        }
        else
        {
            this.Salary += Salary * (bonus / 100);
        }
    }
}