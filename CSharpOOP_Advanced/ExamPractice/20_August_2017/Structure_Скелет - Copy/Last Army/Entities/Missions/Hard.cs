
public class Hard : Mission
{
    private const string HardName = "Disposal of terrorists";
    private const double HardEnduranceRequired = 80;
    private const double HardWearLevelDecrement = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => HardName;

    public override double WearLevelDecrement => HardWearLevelDecrement;

    public override double EnduranceRequired => HardEnduranceRequired;
}
