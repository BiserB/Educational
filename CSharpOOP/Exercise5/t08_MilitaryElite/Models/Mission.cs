
public class Mission : IMission
{
    private string codeName;
    private State state;

    public Mission(string codeName, State state)
    {
        CodeName = codeName;
        State = state;
    }

    public string CodeName
    {
        get { return codeName; }
        set { codeName = value; }
    }
    public State State
    {
        get { return state; }
        set { state = value; }
    }
    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}