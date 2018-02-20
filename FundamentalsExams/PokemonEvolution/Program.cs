using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new Dictionary<string, List<Pokemon>>();            
            string entryData = Console.ReadLine();
            string[] delimiter = new string[] { " -> " };
            while (entryData != "wubbalubbadubdub")
            {
                string[] data = entryData.Split(delimiter, StringSplitOptions.None);
                if (data.Length > 1)
                {
                    string name = data[0];
                    string type = data[1];
                    int index = int.Parse(data[2]);
                    if (!names.ContainsKey(name))
                    {
                        names[name] = new List<Pokemon>();
                    }
                    Pokemon poke = Pokemon.CreatePokemon(type, index);
                    names[name].Add(poke);                    
                }
                else
                {
                    string name = data[0];
                    if (names.ContainsKey(name))
                    {
                        Console.WriteLine("# {0}", name);
                        foreach (Pokemon poke in names[name])
                        {
                            Console.WriteLine("{0} <-> {1}", poke.Type, poke.Index);
                        }
                    }
                }
                entryData = Console.ReadLine();
            }
            foreach (var name in names)
            {
                Console.WriteLine("# {0}", name.Key);
                foreach (Pokemon poke in name.Value.OrderByDescending(p => p.Index))
                {
                    Console.WriteLine("{0} <-> {1}", poke.Type, poke.Index);
                }
            }
        }
    }
     class Pokemon
    {
        public string Type { get; set; }
        public int Index { get; set; }
        public static Pokemon CreatePokemon(string type, int index)
        {
            return new Pokemon
            {
                Type = type,
                Index = index
            };
        }
    }
}
