using System;

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
