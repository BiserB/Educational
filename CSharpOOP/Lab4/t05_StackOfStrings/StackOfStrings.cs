using System;
using System.Collections.Generic;
using System.Text;


public class StackOfStrings
{
    private List<string> data ;

    public StackOfStrings()
    {
        this.Data = new List<string>();
    }

    public List<string> Data
    {
        get { return data; }
        set { data = value; }
    }

    public void Push(string item)
    {
        Data.Add(item);
    }

    public string Pop()
    {
        int cnt = Data.Count;
        string last = string.Empty;
        if (cnt != 0)
        {
            last = Data[cnt - 1];
            Data.RemoveAt(cnt - 1);
        }        
        return last;
    }
    public string Peek()
    {
        int cnt = Data.Count;
        string last = string.Empty;
        if (cnt != 0)
        {
            last = Data[cnt - 1];            
        }
        return last;
    }
    public bool IsEmpty()
    {       
        return Data.Count == 0;
    }
}
