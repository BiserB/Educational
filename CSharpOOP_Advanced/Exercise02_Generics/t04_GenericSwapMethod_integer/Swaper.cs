
using System.Collections.Generic;

public static class Swaper<T>
{
    public static void Swap(List<T> list, int left, int right)
    {
        T temp = list[left];
        list[left] = list[right];
        list[right] = temp;
    }
}
