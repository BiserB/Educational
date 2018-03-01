public class Gem
{
    public string Name { get; set; }
    public long Amount { get; set; }

    public Gem(string name, long amount)
    {
        this.Name = name;
        this.Amount = amount;
    }
}