
using System;

public class Human
{
    private readonly int FIRST_MIN_LENGTH = 4;
    private readonly int LAST_MIN_LENGTH = 3;
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }


    public string FirstName
    {
        get { return firstName; }
        set
        {
            Check(value, "firstName");
            firstName = value;
        }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            Check(value, "lastName");
            lastName = value;
        }
    }

    private void Check(string value, string type)
    {
        if (string.IsNullOrWhiteSpace(value) || !Char.IsUpper(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {type}");
        }
        if (type == "firstName" && value.Length < FIRST_MIN_LENGTH)
        {
            throw new ArgumentException($"Expected length at least {FIRST_MIN_LENGTH} symbols! Argument: firstName");           
        }
        else if(value.Length < LAST_MIN_LENGTH)
        {
            throw new ArgumentException($"Expected length at least {LAST_MIN_LENGTH} symbols! Argument: lastName");
        }
        
    }

}