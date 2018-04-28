using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    private static List<int>[] graph;

    static void Main()
    {
        graph = new List<int>[]
        {
            new List<int>{ 1 ,2 },
            new List<int>{ 3 ,4 },
            new List<int>{ 5 },
            new List<int>{ 2, 5 },
            new List<int>{ 3 },
            new List<int>{  }
        };

        var result = new List<int>();

        var nodes = new HashSet<int>();

        HashSet<int> nodesWithIncomingEdges = GetNodesWithIncomingEdges();

        for (int i = 0; i < graph.Length; i++)
        {
            if (!nodesWithIncomingEdges.Contains(i))
            {
                nodes.Add(i);
            }
        }

        while (nodes.Count != 0)
        {
            int currentNode = nodes.First();
            result.Add(currentNode);
            nodes.Remove(currentNode);

            List<int> children = graph[currentNode];

            graph[currentNode] = new List<int>();

            var leftNodes = GetNodesWithIncomingEdges();            
            

            foreach (var child in children)
            {
                if (!leftNodes.Contains(child))
                {
                    nodes.Add(child);
                }
            }
        }

        if (graph.SelectMany(s => s).Any())
        {
            Console.WriteLine("Error!");
        }
        else
        {
            Console.WriteLine(string.Join(" ", result));
        }

    }

    private static HashSet<int> GetNodesWithIncomingEdges()
    {
        var nodesWithIncomingEdges = new HashSet<int>();

        foreach (var collection in graph)
        {
            foreach (var number in collection)
            {
                if (!nodesWithIncomingEdges.Contains(number))
                {
                    nodesWithIncomingEdges.Add(number);
                }
            }
        }

        return nodesWithIncomingEdges;
    }
}
