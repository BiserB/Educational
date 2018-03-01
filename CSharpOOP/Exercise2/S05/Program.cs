using System;
using System.Linq;

public class Program
{
    public static Bag bag = new Bag();
    public static long capacity;

    static void Main()
    {
        capacity = long.Parse(Console.ReadLine());        

        ReadInput();

        PrintBag();
    }   

    private static void ReadInput()
    {
        string[] input = Console.ReadLine()
                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length - 1; i += 2)
        {
            string type = input[i];
            long amount = long.Parse(input[i + 1]);
            if (bag.Total + amount <= capacity)
            {
                if (type.Length == 3) 
                {
                    AddCash(type, amount);                    
                }                
                else if (type.ToLower().EndsWith("gem"))
                {
                    AddGem(type, amount);
                }
                else if (type.ToLower() == "gold")
                {
                    AddGold(amount);
                }
            }
        }

    }
    
    public static void AddGold(long amount)
    {
        bag.Gold += amount;        
    }

    private static void AddGem(string type, long amount)
    {
        if (bag.Gems.Sum(g => g.Amount) + amount <= bag.Gold)
        {
            Gem gemType = bag.Gems.FirstOrDefault(g => g.Name == type);
            if (gemType == null)
            {
                gemType = new Gem(type, 0);
                bag.Gems.Add(gemType);
            }
            gemType.Amount += amount;
        }
    }

    private static void AddCash(string type, long amount)
    {
        if (bag.Money.Sum(g => g.Amount) + amount <= bag.Gems.Sum(g => g.Amount))
        {
            Cash money = bag.Money.FirstOrDefault(m => m.Name == type);
            if (money == null)
            {
                money = new Cash(type, 0);
                bag.Money.Add(money);
            }
            money.Amount += amount;
        }
    }

    private static void PrintBag()
    {
        if (bag.Gold > 0)
        {
            Console.WriteLine($"<Gold> ${bag.Gold}");
            Console.WriteLine($"##Gold - {bag.Gold}");
        }
        if (bag.Gems.Count > 0 && bag.Gems.Sum(g => g.Amount) > 0)
        {
            Console.WriteLine($"<Gem> ${bag.Gems.Sum(g => g.Amount)}");
            bag.Gems.OrderByDescending(g => g.Name)
                    .ThenBy(g => g.Amount).ToList()
                    .ForEach(g => Console.WriteLine($"##{g.Name} - {g.Amount}"));
        }
        if (bag.Money.Count > 0 && bag.Money.Sum(g => g.Amount) > 0)
        {
            Console.WriteLine($"<Cash> ${bag.Money.Sum(g => g.Amount)}");
            bag.Money.OrderByDescending(g => g.Name)
                    .ThenBy(g => g.Amount).ToList()
                    .ForEach(m => Console.WriteLine($"##{m.Name} - {m.Amount}"));
        }
    }
}
