
using System;

public class Spy : ISoldier, ISpy
{
    private int id;
    private string firstName;
    private string lastName;
    private int codeNumber;

    public Spy(int id, string firstName, string lastName, int codeNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CodeNumber = codeNumber;
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
    public int CodeNumber
    {
        get { return codeNumber; }
        set { codeNumber = value; }
    }

    public override string ToString()
    {
        string result = $"Name: {FirstName} {LastName} Id: {Id}";
        result += Environment.NewLine + $"Code Number: {CodeNumber}";
        return result;
    }
}
