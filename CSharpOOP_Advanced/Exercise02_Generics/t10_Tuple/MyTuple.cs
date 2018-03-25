using System;
using System.Collections.Generic;
using System.Text;


public class MyTuple<T1, T2>
{
    private T1 item1;
    private T2 item2;

    public MyTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
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

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}