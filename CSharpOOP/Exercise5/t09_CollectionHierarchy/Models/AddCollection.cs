using System;
using System.Collections;
using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    private List<string> list;

    public AddCollection()
    {
        List = new List<string>();
    }
    public AddCollection(List<string> list)
    {
        List = list;
    }

    public List<string> List
    {
        get { return list; }
        set { list = value; }
    }

    public int Add(string str)
    {
        this.List.Add(str);
        return List.Count - 1;
    }
}
