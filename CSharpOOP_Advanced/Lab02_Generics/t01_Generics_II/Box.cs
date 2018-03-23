
using System.Collections.Generic;

public class Box<T>
{
    private readonly List<T> register;

    public Box()
    {
        register = new List<T>();
    }

    public int Count
    {
        get { return register.Count; }
    }

    public void Add(T element)
    {
        register.Add(element);        
    }

    public T Remove()
    {
        int top = Count - 1;
        T element = register[top];
        register.RemoveAt(top);
        return element;
    }

}