using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Models.Enums;


namespace P07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {    
        public Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            int modifier = (int)clarity;
            this.Strength = strength + modifier;
            this.Agility = agility + modifier;
            this.Vitality = vitality + modifier;
            this.Clarity = clarity;
        }

        public int Strength { get; }

        public int Agility { get; }

        public int Vitality { get; }

        public Clarity Clarity { get; }
    }
}
