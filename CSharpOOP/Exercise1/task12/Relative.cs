public class Relative
{
    public Relative(string relativeName, string birthday)
    {
        this.Name = relativeName;
        this.Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}