using System.Collections.Generic;

public class Box<T>
{
    private readonly List<T> register;
    private int count;

    public Box()
    {
        register = new List<T>();
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(T element)
    {
        register.Add(element);
        count++;
    }

    public T Remove()
    {
        count--;
        T element = register[count];
        register.RemoveAt(count);
        return element;
    }
}
