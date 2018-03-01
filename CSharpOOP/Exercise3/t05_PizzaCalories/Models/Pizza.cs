using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace t05_PizzaCalories.Models
{
    public class Pizza
    {
        private readonly int MIN_LENGTH = 1;
        private readonly int MAX_LENGTH = 15;
        private readonly int MAX_TOPPINGS = 10;

        private string name;
        private Dough dough;
        private decimal totalCalories;
        public Pizza()
        {
            Toppings = new List<Topping>();
        }

        public Pizza(string name) : this()
        {
            Name = name;
            NumberOfToppings = 0;            
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Pizza name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.");
                }                
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public decimal TotalCalories
        {
            get { return totalCalories; }
            private set { totalCalories = value; }
        }

        private List<Topping> Toppings { get; set; }
        public int NumberOfToppings { get; set; }

        private decimal CalcCalories()
        {
            decimal cal = Dough.Calories;
            cal += Toppings.Sum(t => t.Calories);
            return cal;
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings > MAX_TOPPINGS)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MAX_TOPPINGS}].");
            }
            Toppings.Add(topping);
            NumberOfToppings++;
            TotalCalories = CalcCalories();
        }

        public void AddDough(Dough dough)
        {
            this.Dough = dough;
            TotalCalories = CalcCalories();
        }
    }
}
