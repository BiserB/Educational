using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, Dictionary<string, Stats>>();
            for (int i = 0; i < num; i++)
            {
                //  {type} {name} {damage} {health} {armor}
                string[] data = Console.ReadLine().Split(' ');
                string type = data[0];
                string name = data[1];
                
                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new Dictionary<string, Stats>();
                } 
                dragons[type][name] = NewDragon(data);
            }
            foreach (var dragon in dragons)
            {
                var averageDamage = dragon.Value.Values.Select(p => p.Damage).Average();
                var averageHealth = dragon.Value.Values.Select(p => p.Health).Average();
                var averageArmour = dragon.Value.Values.Select(p => p.Armour).Average();                
                
                Console.WriteLine("{0}::({1:0.00}/{2:0.00}/{3:0.00})",dragon.Key, averageDamage, averageHealth, averageArmour);
                foreach (var item in dragon.Value.OrderBy(p => p.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", item.Key, item.Value.Damage, item.Value.Health, item.Value.Armour);
                }                
            }

        }
        public static Stats NewDragon(string[] data)
        {            
            int damage = 45;
            if (data[2] != "null")
            {
                damage = int.Parse(data[2]);
            }
            int health = 250;
            if (data[3] != "null")
            {
                health = int.Parse(data[3]);
            }
            int armour = 10;
            if (data[4] != "null")
            {
                armour = int.Parse(data[4]);
            }
            return new Stats
            { 
                Damage = damage,
                Health = health,
                Armour = armour
            };
        }

    }
    class Stats
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }
    }
}
