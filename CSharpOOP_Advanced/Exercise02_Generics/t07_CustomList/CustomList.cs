using System;
using System.Collections.Generic;
using System.Text;


public class CustomList<T> where T: IComparable<T>
{
    private List<T> content;

    public CustomList()
    {
        content = new List<T>();
    }

    public void Add(T element)
    {
        content.Add(element);
    }

    public T Remove(int index)
    {
        T element = content[index];
        content.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        if (content.Contains(element))
        {
            return true;
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = content[index1];
        content[index1] = content[index2];
        content[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int greater = 0;

        foreach (var item in content)
        {
            if (item.CompareTo(element) > 0)
            {
                greater++;
            }
        }
        return greater;
    }

    public T Max()
    {
        T max = content[0];

        foreach (var item in content)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }

    public T Min()
    {
        T min = content[0];

        foreach (var item in content)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    public string PrintAll()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in content)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
