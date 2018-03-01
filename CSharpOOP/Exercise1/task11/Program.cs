using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        string input = "";

        List<Trainer> trainers = new List<Trainer>();        

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] data = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = data[0];
            string name = data[1];
            string element = data[2];
            int health = int.Parse(data[3]);

            Pokemon newPokemon = new Pokemon(name, element, health);
            Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
            if (trainer == null)
            {
                Trainer newTrainer = new Trainer(trainerName, newPokemon);
                trainers.Add(newTrainer);
            }
            else
            {
                trainer.AddPokemon(newPokemon);
            }
        }
        while ((input = Console.ReadLine()) != "End")
        {
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.numberOfBadges++;
                }
                else
                {                    
                    int count = trainer.Pokemons.Count;
                    for (int i = 0; i < count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            count--;
                        }                        
                    }
                }
            }
        }
        foreach (Trainer trainer in trainers.OrderByDescending(t => t.numberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.numberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}
