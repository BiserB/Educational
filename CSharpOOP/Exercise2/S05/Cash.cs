public class Cash
{
    public string Name { get; set; }
    public long Amount { get; set; }

    public Cash(string name, long amount)
    {
        this.Name = name;
        this.Amount = amount;
    }
}