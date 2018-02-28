using System;

namespace t11_II
{
    class Program
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            bool[][] parkingLot = new bool[rows][];

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                string[] args = input.Split();
                int z = int.Parse(args[0]);
                int x = int.Parse(args[1]);
                int y = int.Parse(args[2]);

                if (parkingLot[x] == null)
                {
                    parkingLot[x] = new bool[cols];
                }

                int carX = z;
                int carY = 0;

                int steps = 1;

                steps += Math.Abs(carX - x);
                carX = x;

                steps += Math.Abs(carY - y);
                carY = y;

                if (parkingLot[carX][carY] == false)
                {
                    parkingLot[carX][carY] = true;
                    Console.WriteLine(steps);
                }
                else
                {
                    //Searching closest free spot
                    int counter = 1;
                    while (true)
                    {
                        int leftDir = carY - counter;
                        int rightDir = carY + counter;

                        if (leftDir <= 0 && rightDir >= cols)
                        {
                            Console.WriteLine($"Row {x} full");
                            break;
                        }
                        if (leftDir > 0 && leftDir < cols && parkingLot[carX][leftDir] == false)
                        {
                            parkingLot[carX][leftDir] = true;
                            steps -= counter;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (rightDir > 0 && rightDir < cols && parkingLot[carX][rightDir] == false)
                        {
                            parkingLot[carX][rightDir] = true;
                            steps += counter;
                            Console.WriteLine(steps);
                            break;
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
