using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T1, T2, T3>
{
    private T1 item1;
    private T2 item2;
    private T3 item3;

    public Threeuple(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public T1 Item1
    {
        get { return item1; }
        private set { item1 = value; }
    }

    public T2 Item2
    {
        get { return item2; }
        private set { item2 = value; }
    }

    public T3 Item3
    {
        get { return item3; }
        private set { item3 = value; }
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2} -> {Item3}";
    }
}
