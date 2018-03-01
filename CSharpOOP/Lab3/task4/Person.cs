// Expand Person with proper validation for every field:
// Names must be at least 3 symbols
// Age must not be zero or negative
// Salary can't be less than 460.0 

using System;

public class Person
{
    private readonly int MIN_LENGTH = 3;
    private readonly decimal MIN_SALARY = 460m;

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
        private set
        {
            if (value?.Length < MIN_LENGTH)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_LENGTH} symbols!");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value?.Length < MIN_LENGTH)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_LENGTH} symbols!");
            }
            lastName = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }
            salary = value;
        }
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