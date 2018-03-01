using System;
using System.Collections.Generic;
using System.Text;
using t05_PizzaCalories.Models.Enums;

namespace t05_PizzaCalories.Models
{
    public class Topping
    {
        private readonly int MIN_WEIGHT = 1;
        private readonly int MAX_WEIGHT = 50;

        public ToppingType Type { get; set; }
        private decimal weight;
        private decimal calories;

        public Topping(ToppingType type, decimal weight)
        {
            Type = type;
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
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
                }
                weight = value;
            }
        }

        public decimal Calories
        {
            get { return calories; }
            private set { calories = value; }
        }

        private decimal CalcCalories()
        {
            decimal calPerGram = 2.0m;

            switch (this.Type)
            {
                case ToppingType.Meat:
                    calPerGram *= 1.2m;
                    break;
                case ToppingType.Veggies:
                    calPerGram *= 0.8m;
                    break;
                case ToppingType.Cheese:
                    calPerGram *= 1.1m;
                    break;
                case ToppingType.Sauce:
                    calPerGram *= 0.9m;
                    break;                
            }
            return calPerGram * Weight;
        }
    }
}
