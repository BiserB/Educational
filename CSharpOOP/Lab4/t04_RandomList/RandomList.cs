using System;
using System.Collections.Generic;
using System.Text;


public class RandomList:List<string>
{
    public string RandomString(List<string> list)
    {
        int cnt = list.Count;
        if (cnt == 0)
        {
            return null;
        }
        Random newRandom = new Random();
        int index = newRandom.Next(0, cnt);
        string str = list[index];
        list.RemoveAt(index);
        return str;
    }
}
