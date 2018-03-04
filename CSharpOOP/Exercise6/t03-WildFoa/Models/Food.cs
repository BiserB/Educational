
public class Food
{
    private int quantity;
    private string type;

    public Food(string type, int quantity)
    {
        Type = type;
        Quantity = quantity;
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

}
