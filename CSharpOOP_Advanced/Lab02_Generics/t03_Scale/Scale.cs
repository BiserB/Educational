
using System;

public class Scale<T> where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T l, T r)
    {
        left = l;
        right = r;
    }

    public T GetHeavier()
    {
        if (left.CompareTo(right) > 0)
        {
            return left;
        }
        else if (left.CompareTo(right) < 0)
        {
            return right;
        }
        return default(T);
    }

}
