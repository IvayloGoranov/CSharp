using System;
using System.Collections.Generic;
using System.Linq;

public class AdjacencyMatrixGraph
{
    static int[,] graph =
        { // 0  1  2  3  4  5  6
           { 0, 0, 0, 1, 0, 0, 1 }, // node 0
           { 0, 0, 1, 1, 1, 1, 1 }, // node 1
           { 0, 1, 0, 0, 1, 1, 0 }, // node 2
           { 1, 1, 0, 0, 0, 1, 0 }, // node 3
           { 0, 1, 1, 0, 0, 0, 1 }, // node 4
           { 0, 1, 1, 1, 0, 0, 0 }, // node 5
           { 1, 1, 0, 0, 1, 0, 0 }, // node 6
        };
    static string[] nodeNames = new string[] { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

    public static void Main()
    {
        //int[,] graph = ReadGraphMatrix();

        PrintGraphMatrix(graph);

        Console.WriteLine();

        PrintNodesWithChildren(graph, nodeNames);
    }

    private static int[,] ReadGraphMatrix()
    {
        int nodesCount = int.Parse(Console.ReadLine());
        var graph = new int[nodesCount, nodesCount];

        // Read children for each node
        for (int parentNode = 0; parentNode < nodesCount; parentNode++)
        {
            var childNodes = Console.ReadLine().Split(' ').Select(int.Parse);
            foreach (int childNode in childNodes)
            {
                graph[parentNode, childNode] = 1;
            }
        }

        return graph;
    }

    static void PrintGraphMatrix(int[,] graph)
    {
        for (int row = 0; row < graph.GetLength(0); row++)
        {
            for (int col = 0; col < graph.GetLength(1); col++)
            {
                Console.Write(graph[row, col] + " ");
            }

            Console.WriteLine();
        }
    }

    static void PrintNodesWithChildren(int[,] graph, string[] nodeNames)
    {
        for (int row = 0; row < graph.GetLength(0); row++)
        {
            var childNodes = new List<string>();
            for (int col = 0; col < graph.GetLength(1); col++)
            {
                if (graph[row, col] != 0)
                {
                    childNodes.Add(nodeNames[col]);
                }
            }
            Console.WriteLine("{0} --> {1}",
                nodeNames[row],
                string.Join(", ", childNodes));
        }
    }
}
