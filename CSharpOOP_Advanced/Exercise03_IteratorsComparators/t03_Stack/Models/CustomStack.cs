
using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : IEnumerable<T>
{
    private List<T> collection;

    public CustomStack()
    {
        collection = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = collection.Count - 1; i >= 0; i--)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Push(T element)
    {
        collection.Add(element);
    }

    public T Pop()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }
        T result = collection[collection.Count - 1];
        collection.RemoveAt(collection.Count - 1);
        return result;
    }
}
