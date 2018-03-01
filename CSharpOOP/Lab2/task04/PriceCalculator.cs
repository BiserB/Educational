

public class PriceCalculator
{     

    public static decimal Calculate(decimal pricePerDay, int numberOfDays, string season, string discount)
    {
        int multiplier = 1;
        decimal disc = 1m;
        switch (season)
        {
            case "Autumn":
                multiplier = 1;
                break;
            case "Spring":
                multiplier = 2;
                break;
            case "Winter":
                multiplier = 3;
                break;
            case "Summer":
                multiplier = 4;
                break;
        }
        switch (discount)
        {
            case "VIP":
                disc = 0.8m;
                break; 
            case "SecondVisit":
                disc = 0.9m;
                break;            
        }

        return multiplier * disc * pricePerDay * numberOfDays;
    }
}
