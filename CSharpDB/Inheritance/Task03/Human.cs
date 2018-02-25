using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public class Human
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        protected set
        {
            string pattern = @"[A-Z]\w*";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }    
    public string LastName
    {
        get { return this.lastName; }
        protected set
        {
            string pattern = @"[A-Z]\w*";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

}

