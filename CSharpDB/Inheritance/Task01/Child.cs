using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Child : Person    
{  
    public Child(string name, int age) : base(name, age)
    {
        if (age > 15)
        {
            throw new ArgumentException("Child's age must be less than 15!");
        }
    }
}
