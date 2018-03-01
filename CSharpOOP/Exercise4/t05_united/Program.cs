using System;


public class Program
{
    static void Main()
    {
        int points = 0;
        FoodCreator fc = new FoodCreator();
        string[] delimiter = new string[] { " " };
        string[] data = Console.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in data)
        {
            var food = fc.CreateFood(str);
            points += food.Points;
        }

        Console.WriteLine(points);
        Console.WriteLine(Evaluate(points));
    }
    public static string Evaluate(int points)
    {
        if (points < -5)
        {
            return "Angry";
        }
        else if (points >= -5 && points <= 0)
        {
            return "Sad";
        }
        else if (points >= 1 && points <= 15)
        {
            return "Happy";
        }
        return "JavaScript";
    }

}
class Food
{
    private int points;

    public int Points
    {
        get { return points; }
        set { points = value; }
    }
}
class Apple : Food
{
    public Apple(int points) { base.Points = points; }
}
class Cram : Food
{
    public Cram(int points) { base.Points = points; }
}
class Lembas : Food
{
    public Lembas(int points) { base.Points = points; }
}
class Melon : Food
{
    public Melon(int points) { base.Points = points; }
}
class HoneyCake : Food
{
    public HoneyCake(int points) { base.Points = points; }
}
class Mushrooms : Food
{
    public Mushrooms(int points) { base.Points = points; }
}
class Other : Food
{
    public Other(int points) { base.Points = points; }
}

abstract class Creator
{
    public abstract Food CreateFood(string type);
}

class FoodCreator : Creator
{
    public override Food CreateFood(string type)
    {
        switch (type.ToLower())
        {
            case "cram": return new Cram(2);
            case "lembas": return new Lembas(3);
            case "apple": return new Apple(1);
            case "melon": return new Melon(1);
            case "honeycake": return new HoneyCake(5);
            case "mushrooms": return new Mushrooms(-10);
            default: return new Other(-1);
        }
    }
}

