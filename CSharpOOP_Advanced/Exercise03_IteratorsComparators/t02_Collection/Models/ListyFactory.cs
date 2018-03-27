
public class ListyFactory
{
    public ListyIterator<T> Create<T>(params T[] elements)
    {
        return new ListyIterator<T>(elements);
    }
}
