
public abstract class Mission : IMission
{
    public Mission(string name, double enduranceRequired, double scoreToComplete)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name { get; }

    public double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public abstract double WearLevelDecrement { get; }
}
