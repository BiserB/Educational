using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<int>[] graph;
    private static List<int[]> connections;
    private static List<int> paths;

    static void Main()
    {
        ReadInput();

        FindDistances();
    }

    private static void FindDistances()
    {
        paths = new List<int>();

        for (int i = 0; i < connections.Count; i++)
        {
            int startIndex = connections[i][0] - 1;
            int endIndex = connections[i][1] - 1;

            List<int> startNode = graph[startIndex];

            int result = -1;

            foreach (int child in startNode)
            {
                result = Traverse(child - 1, endIndex, 1);                
            }

            paths.Add(result);
        }

        Console.WriteLine(string.Join(" ,", paths));
    }

    private static int Traverse(int node, int endIndex, int counter)
    {
        if (node == endIndex)
        {
            return counter;
        }

        List<int> nextNode = graph[node];

        foreach (var num in nextNode)
        {
            Traverse(num - 1, endIndex, counter += 1);
        }
       

        return -1;
    }

    private static void ReadInput()
    {
        int nodes = int.Parse(Console.ReadLine());
        int pairs = int.Parse(Console.ReadLine());

        graph = new List<int>[nodes];
        connections = new List<int[]>(pairs);

        for (int i = 0; i < nodes; i++)
        {
            string[] data = Console.ReadLine()
                        .Split(new string[] { ":", " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();

            List<int> nodeChildrens = new List<int>();

            foreach (string num in data)
            {
                int n = int.Parse(num);

                nodeChildrens.Add(n);
            }                             

            graph[i] = nodeChildrens;
        }

        for (int i = 0; i < pairs; i++)
        {
            int[] data = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

            connections.Add(data);           
        }
    }
}