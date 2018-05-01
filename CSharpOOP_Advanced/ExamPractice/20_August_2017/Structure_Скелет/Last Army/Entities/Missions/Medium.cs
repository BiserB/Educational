
public class Medium : Mission
{
    private const string Name = "Capturing dangerous criminals";
    private const double EnduranceRequired = 50;
    private const double ScoreToComplete = 50;

    public Medium(): base(Name, EnduranceRequired, ScoreToComplete)
    {
    }

    public override double WearLevelDecrement => 50;
}