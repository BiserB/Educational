
using System;
using System.Collections.Generic;

public class Comparer<T> where T : IComparable<T>
{
    public static int Compare(List<T> list, T threshold)
    {
        int greater = 0;

        foreach (var item in list)
        {
            if (item.CompareTo(threshold) > 0)
            {
                greater++;
            }
        }
        return greater;
    }
}
