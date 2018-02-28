using System;

namespace t10
{
    class Program
    {
        static void Main()
        {
            double lifeOfHeigan = 3000000d;
            double damageBoss = double.Parse(Console.ReadLine());
            int playerLife = 18500;
            int playerRow = 7;
            int playerCol = 7;
            int damageToPlayer = 0;
            bool damagedPlayer = false;
            int[,] matrix = new int[15, 15];

            string spell = "";
            string residualSpell = "";

            while (playerLife >= 0)
            {
                lifeOfHeigan -= damageBoss;
                if (lifeOfHeigan < 0)
                {
                    break;
                }
                string[] input = Console.ReadLine().Split();
                spell = input[0];
                int strikeRow = int.Parse(input[1]);
                int strikeCol = int.Parse(input[2]);
                if (spell == "Cloud")
                {
                    damageToPlayer = 3500;
                }
                else if (spell == "Eruption")
                {
                    damageToPlayer = 6000;
                }
                
                
                if (residualSpell == "Cloud" && damagedPlayer)
                {
                    playerLife -= 3500;
                }
                if (playerLife <= 0)
                {
                    break;
                }
                residualSpell = spell;
                //---------------------------------------populate matrix coordinates with damage
                for (int r = 0; r < 15; r++)
                {
                    for (int c = 0; c < 15; c++)
                    {
                        if (r >= strikeRow - 1 && r <= strikeRow + 1 && c >= strikeCol - 1 && c <= strikeCol + 1)
                        {
                            matrix[r, c] = damageToPlayer;
                        }
                    }
                }

                //--------------------------------------try to escape
                damagedPlayer = false;
                if (matrix[playerRow, playerCol] > 0)                       // if current cell is damaged
                {
                    playerRow = playerRow - 1;
                    if (playerRow < 0 || matrix[playerRow, playerCol] > 0)  // if damage in upper cell
                    {
                        playerRow = playerRow + 1;
                        playerCol = playerCol + 1;
                        if (playerCol > 14 || matrix[playerRow, playerCol] > 0) // -check right
                        {
                            playerRow = playerRow + 1;
                            playerCol = playerCol - 1;
                            if (playerRow > 14 || matrix[playerRow, playerCol] > 0) // -check down
                            {
                                playerRow = playerRow - 1;
                                playerCol = playerCol - 1;
                                if ( playerCol < 0 || matrix[playerRow, playerCol] > 0) // -check left
                                {                                   
                                    playerCol = playerCol + 1;
                                    damagedPlayer = true;
                                }                                
                            }
                        }
                    }
                }
                //------------------ take the damage in current cell
                
                playerLife -= matrix[playerRow, playerCol];
                
                //Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                //Console.WriteLine($"playerLife: {playerLife}");
                Array.Clear(matrix, 0, matrix.Length);                
            }

            if (lifeOfHeigan <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {lifeOfHeigan:0.00}");
            }
            if (playerLife <= 0)
            {
                if (residualSpell == "Cloud")
                {
                    residualSpell = "Plague Cloud";
                }
                Console.WriteLine($"Player: Killed by {residualSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerLife}");
            }
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }
        public static void PrintMatrix(int[,] matrix)
        {

            Console.WriteLine();
            for (int r = 0; r < 15; r++)
            {
                for (int c = 0; c < 15; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
