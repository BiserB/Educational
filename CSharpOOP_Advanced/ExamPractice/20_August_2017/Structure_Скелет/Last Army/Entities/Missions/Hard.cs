
public class Hard : Mission
{
    private const string Name = "Disposal of terrorists";
    private const double EnduranceRequired = 80;
    private const double ScoreToComplete = 80;

    public Hard(): base(Name, EnduranceRequired, ScoreToComplete)
    {
    }

    public override double WearLevelDecrement => 70;
}
