using System;
using System.Collections.Generic;
using System.Linq;

class Graph
{
    public List<int>[] ChildNodes { get; set; }
    public string[] NodeNames { get; set; }

    public Graph(List<int>[] childNodes, string[] nodeNames = null)
    {
        this.ChildNodes = childNodes;
        this.NodeNames = nodeNames;
    }
}

public class AdjacencyListGraph
{
    public static void Main()
    {
        var graph = new Graph(new[]
            {
                new List<int> {3, 6}, // children of node 0 (Ruse)
                new List<int> {2, 3, 4, 5, 6}, // children of node 1 (Sofia)
                new List<int> {1, 4, 5}, // children of node 2 (Pleven)
                new List<int> {0, 1, 5}, // children of node 3 (Varna)
                new List<int> {1, 2, 6}, // children of node 4 (Bourgas)
                new List<int> {1, 2, 3}, // children of node 5 (Stara Zagora)
                new List<int> {0, 1, 4}  // children of node 6 (Plovdiv)
            },
            new string[] { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" }
        );

        // Print the nodes and their children
        for (int nodeIndex = 0; nodeIndex < graph.ChildNodes.Length; nodeIndex++)
        {
            Console.WriteLine("{0} -> {1}", nodeIndex,
                string.Join(" ", graph.ChildNodes[nodeIndex]));
        }

        Console.WriteLine();

        // Print the node names and their children names
        for (int nodeIndex = 0; nodeIndex < graph.ChildNodes.Length; nodeIndex++)
        {
            Console.WriteLine("{0} -> {1}",
                graph.NodeNames[nodeIndex],
                string.Join(", ", graph.ChildNodes[nodeIndex]
                    .Select(node => graph.NodeNames[node])));
        }
    }
}
