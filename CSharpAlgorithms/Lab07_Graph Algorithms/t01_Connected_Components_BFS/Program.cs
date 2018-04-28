using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private static int num;
    private static List<int>[] graph;
    private static Queue<int> nextElements;
    private static bool[] visited;

    static void Main()
    {
        EnterData();

        BFS(0);

    }

    private static void EnterData()
    {
        num = int.Parse(Console.ReadLine());

        graph = new List<int>[num];

        visited = new bool[num];

        nextElements = new Queue<int>();

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
    }

    private static void BFS(int node)
    {
        if (visited[node])
        {
            return;
        }

        nextElements.Enqueue(node);
        visited[node] = true;

        while (nextElements.Count != 0)
        {
            int currentNode = nextElements.Dequeue();

            Console.Write(currentNode + " ");

            foreach (int number in graph[currentNode])
            {
                if (!visited[number])
                {
                    nextElements.Enqueue(number);

                    visited[number] = true;
                }
                
            }
                        
        }
    }
}
