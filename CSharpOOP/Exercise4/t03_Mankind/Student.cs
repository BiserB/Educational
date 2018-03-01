
using System;

public class Student: Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) :base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            CheckNumber(value);
            facultyNumber = value;
        }
    }

    private void CheckNumber(string value)
    {
        if (String.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 10)
        {
            throw new ArgumentException("Invalid faculty number!");
        }
        foreach (char ch in value)
        {
            if (!Char.IsDigit(ch) && !Char.IsLetter(ch))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
        }
    }

    public override string ToString()
    {
        string result = $"First Name: {this.FirstName}" + Environment.NewLine;
        result += $"Last Name: {this.LastName}" + Environment.NewLine;
        result += $"Faculty number: {this.FacultyNumber}";
        return result;        
    }

}