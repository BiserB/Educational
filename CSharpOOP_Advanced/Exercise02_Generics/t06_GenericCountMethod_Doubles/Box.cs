
using System;

public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
{
    private T content;

    public Box(T content)
    {
        this.content = content;
    }

    public int CompareTo(Box<T> otherBox)
    {
        return content.CompareTo(otherBox.content);
    }

    public override string ToString()
    {
        return $"{content.GetType().FullName}: {content}";
    }
}
