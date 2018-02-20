using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisII
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot jarvis = new Robot();
            long energyTotal = long.Parse(Console.ReadLine());
            jarvis.Energy = energyTotal;
            string input = Console.ReadLine();
            while (input != "Assemble!")
            {
                string[] part = input.Split();
                switch (part[0])
                {
                    case "Arm":
                        Arm arm = new Arm
                        {
                            EnergyConsumption = int.Parse(part[1]),
                            ArmDistance = int.Parse(part[2]),
                            FingersCount = int.Parse(part[3])
                        };
                        jarvis.AddArm(arm);
                        break;
                    case "Leg":
                        Leg leg = new Leg
                        {
                            EnergyConsumption = int.Parse(part[1]),
                            Strength = int.Parse(part[2]),
                            Speed = int.Parse(part[3])
                        };
                        jarvis.AddLeg(leg);
                        break;
                    case "Torso":
                        Torso torso = new Torso
                        {
                            EnergyConsumption = int.Parse(part[1]),
                            Procesor = double.Parse(part[2]),
                            Material = part[3]
                        };
                        jarvis.AddTorso(torso);
                        break;
                    case "Head":
                        Head newhead = new Head
                        {
                            EnergyConsumption = int.Parse(part[1]),
                            IQ = int.Parse(part[2]),
                            Skin = part[3]
                        };
                        jarvis.AddHead(newhead);
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
