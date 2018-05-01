using System;

public class Easy : Mission
{
    private const string Name = "Suppression of civil rebellion";
    private const double EnduranceRequired = 20;
    private const double ScoreToComplete = 20;

    public Easy(): base(Name, EnduranceRequired, ScoreToComplete)
    {
    }

    public override double WearLevelDecrement => 30;
}