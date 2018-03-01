using System.Collections.Generic;

internal class Trainer
{        

    public Trainer(string trainerName, Pokemon newPokemon)
    {
        this.Name = trainerName;
        this.Pokemons.Add(newPokemon);
        this.numberOfBadges = 0;
    }

    public string Name { get; set; }
    public int numberOfBadges { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

    public void AddPokemon(Pokemon poke)
    {
        this.Pokemons.Add(poke);
    }
}