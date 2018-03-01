using System;
using System.Collections.Generic;

public class Program
{
   
    static void Main()
    {
        int points = 0;
        FoodCreator fc = new FoodCreator();
        string[] delimiter = new string[] { " "};
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
