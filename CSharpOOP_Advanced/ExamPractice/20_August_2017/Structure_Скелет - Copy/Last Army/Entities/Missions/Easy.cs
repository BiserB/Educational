using System;

public class Easy : Mission
{
    private const string EasyName = "Suppression of civil rebellion";
    private const double EasyEnduranceRequired = 20;
    private const double EasyWearLevelDecrement = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => EasyName;

    public override double WearLevelDecrement => EasyWearLevelDecrement;

    public override double EnduranceRequired => EasyEnduranceRequired;

    
}