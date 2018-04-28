using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    private static int num;
    private static List<int>[] graph;
    private static bool[] visited;

    static void Main()
    {
        num = int.Parse(Console.ReadLine());

        graph = new List<int>[num];

        for (int i = 0; i < num; i++)
        {
            graph[i] = new List<int>();

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                int[] data = input.Split().Select(int.Parse).ToArray();
                graph[i].AddRange(data);
            }       
        }

        visited = new bool[num];
        
        for (int i = 0; i < num; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                Traverse(i);
                Console.WriteLine();
            }
        }              

    }

    private static void Traverse( int node)
    {
        if (!visited[node])
        {
            visited[node] = true;

            foreach (int number in graph[node])
            {
                Traverse(number);
            }

            Console.Write(" " + node);
        }
    }
}
