
using System.Collections.Generic;

public class AddRemoveCollection : IAddRemoveCollection
{
    private List<string> list;

    public AddRemoveCollection()
    {
        List = new List<string>();
    }

    public AddRemoveCollection(List<string> list)
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
        List<string> temp = new List<string>();
        temp.Add(str);
        temp.AddRange(List);
        List = temp;
        return 0;
    }

    public string Remove(string str)
    {
        int index = List.Count - 1;
        string result = List[index];
        List.RemoveAt(index);
        return result;
    }
}
