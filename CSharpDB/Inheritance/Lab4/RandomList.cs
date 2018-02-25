using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RandomList : List<string>
{
    private Random rnd;

    public RandomList()
        : base()
    {
        this.rnd = new Random();
    }

    public string RandomString()
    {
        int index = rnd.Next(0, this.Count - 1);
        string str = this[index];
        this.Remove(str);
        return str;
    }
}

