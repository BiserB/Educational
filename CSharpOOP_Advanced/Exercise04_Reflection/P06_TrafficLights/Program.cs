using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_TrafficLights
{
    public class Program
    {
        static void Main()
        {
            List<TrafficLight> traficLights = new List<TrafficLight>();

            string[] input = Console.ReadLine().Split();
            int steps = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                Light light;

                if (Enum.TryParse(input[i], out light))
                {
                    TrafficLight tl = new TrafficLight(light);
                    traficLights.Add(tl);
                }                
            }


            for (int i = 0; i < steps; i++)
            {
                string line = "";
                    
                foreach (var tl in traficLights)
                {
                    tl.NextSignal();

                    line += tl.ToString() + " ";
                }
                Console.WriteLine(line.TrimEnd());
            }
        }
    }

    public class TrafficLight
    {
        private Light light;

        public TrafficLight(Light light)
        {
            this.Light = light;
        }
        
        public Light Light
        {
            get { return light; }
            private set
            {                
                light = value;
            }
        }

        public void NextSignal()
        {
            Light maxLight = Enum.GetValues(typeof(Light)).Cast<Light>().Last();
            Light minLight = Enum.GetValues(typeof(Light)).Cast<Light>().First();

            if (this.Light == maxLight)
            {
                Light = minLight;
            }
            else
            {
                Light++;
            }
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }

    }
}
