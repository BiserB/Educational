using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Family 
{
    private List<Person> register;

    private List<Person> Register
    {
        get { return this.register; }
        set { this.register = value; }
    }
    
    public Family( ) 
    {
        this.Register = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.Register.Add(member);
    }

    public Person GetOldestMember()
    {
        int maxAge = Register.Max(p => p.Age);
        return Register.Find(p => p.Age == maxAge);
    }
}
