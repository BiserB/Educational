using System;
using System.Collections.Generic;

public class MyList : IAddRemoveCollection
{
    private List<string> list;
    private int used; 

    public MyList()
    {
        List = new List<string>();
    }

    public MyList(List<string> list)
    {
        List = list;
    }

    public List<string> List
    {
        get { return list; }
        set { list = value; }
    }

    public int Used
    {
        get { return List.Count; }        
    }

    public int Add(string str)
    {
        List<string> temp = new List<string>();
        temp.Add(str);
        temp.AddRange(List);
        List = temp;
        return 0;
    }

    public string Remove(string str)
    {        
        string result = List[0];
        List.RemoveAt(0);
        return result;
    }
}
