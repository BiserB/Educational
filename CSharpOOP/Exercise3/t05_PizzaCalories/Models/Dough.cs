using System;
using System.Collections.Generic;
using System.Text;
using t05_PizzaCalories.Models.Enums;

namespace t05_PizzaCalories.Models
{
    public class Dough
    {
        private readonly int MIN_WEIGHT = 1;
        private readonly int MAX_WEIGHT = 200;

        private decimal weight;
        private FlourType flour;
        private BakingTechnique tech;
        private decimal calories;
        

        public Dough(FlourType flour, BakingTechnique tech, decimal weight)
        {
            Flour = flour;
            Tech = tech;
            Weight = weight;
            Calories = CalcCalories();
        }

        public decimal Weight
        {
            get { return weight; }
            private set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
                }
                weight = value;
            }
        }       

        public FlourType Flour
        {
            get { return flour; }
            private set { flour = value; }
        }       

        public BakingTechnique Tech
        {
            get { return tech; }
            set { tech = value; }
        }

        public decimal Calories
        {
            get { return calories; }
            private set { calories = value; }
        }

        private decimal CalcCalories()
        {
            decimal calPerGram = 2.0m;
            if (this.Flour == FlourType.white)
            {
                calPerGram *= 1.5m;
            }
            switch (this.Tech)
            {
                case BakingTechnique.crispy:
                    calPerGram *= 0.9m;
                    break;
                case BakingTechnique.chewy:
                    calPerGram *= 1.1m;
                    break;                
            }
            return calPerGram * Weight;
        }
    }
}
