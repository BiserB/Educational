public class Pokemon
{
    
    public Pokemon(string pokemonName, string type)
    {
        this.Name = pokemonName;
        this.Type = type;
    }

    public string Name { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}