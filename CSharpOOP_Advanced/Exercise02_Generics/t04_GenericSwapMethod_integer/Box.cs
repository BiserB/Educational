
public class Box<T>
{
    private T content;

    public Box(T content)
    {
        this.content = content;
    }

    public override string ToString()
    {
        return $"{content.GetType().FullName}: {content}";
    }
}
