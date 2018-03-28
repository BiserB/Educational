using System;
using System.Collections;
using System.Collections.Generic;



public class ListyIterator<T> : IEnumerable<T>
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

    public string Print()
    {
        if (currentindex == content.Count || currentindex < 0)
        {
            throw new InvalidOperationException("Invalid operation");
        }
        return content[currentindex].ToString();
    } 

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < content.Count; i++)
        {
            yield return content[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
