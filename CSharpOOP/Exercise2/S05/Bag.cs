
using System.Collections.Generic;
using System.Linq;

public class Bag
{
    public long Gold { get; set; }
    public List<Gem> Gems { get; set; }
    public List<Cash> Money { get; set; }
    private long total;

    public long Total
    {
        get
        {
            long sum = Gold;
            sum += Gems.Sum(g => g.Amount);
            sum += Money.Sum(m => m.Amount);
            return sum;
        }       
    }

    public Bag()
    {
        this.Gold = 0;
        this.Gems = new List<Gem>();
        this.Money = new List<Cash>();
    }
}
