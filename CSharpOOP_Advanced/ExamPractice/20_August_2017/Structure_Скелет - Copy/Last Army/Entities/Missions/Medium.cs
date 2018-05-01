
public class Medium : Mission
{  
    private const string MediumName = "Capturing dangerous criminals";
    private const double MediumEnduranceRequired = 20;
    private const double MediumWearLevelDecrement = 30;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MediumName;

    public override double WearLevelDecrement => MediumWearLevelDecrement;

    public override double EnduranceRequired => MediumEnduranceRequired;
}