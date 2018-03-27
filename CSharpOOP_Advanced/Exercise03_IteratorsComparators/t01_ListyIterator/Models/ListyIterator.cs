using System;
using System.Collections.Generic;



public class ListyIterator<T>
{
    private int currentindex;
    private List<T> content;

    public ListyIterator(params T[] elements)
    {
        currentindex = 0;
        this.content = new List<T>(elements);
    }

    public bool Move()
    {
        if (HasNext())
        {
            currentindex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return currentindex + 1 < content.Count;
    }

    public void Print()
    {
        if (currentindex == content.Count)
        {
            throw new InvalidOperationException("Invalid operation");
        }
        Console.WriteLine(content[currentindex]);
    }
}
