using System;
using System.Collections.Generic;
using System.Linq;

public class Jgmundi
{
    public static void Main()
    {
        // read input
        IList<Edge> edges = new List<Edge>();
        string inputLine = Console.ReadLine();
        int numberOfNodes = int.Parse(inputLine);

        inputLine = Console.ReadLine();
        while (inputLine != string.Empty)
        {
            int[] inputArgs = inputLine.Split(' ').Select(x => int.Parse(x)).ToArray();
            edges.Add(new Edge(inputArgs[0], inputArgs[1], inputArgs[2]));
            if (numberOfNodes <= inputArgs[1])
            {
                numberOfNodes = inputArgs[1] + 1;
            }

            inputLine = Console.ReadLine();
        }

        // initialize
        int[] prevVertex = new int[numberOfNodes];
        long[] distance = new long[numberOfNodes];

        distance[0] = 0; // source
        for (int i = 1; i < numberOfNodes; i++)
        {
            prevVertex[i] = -1;
            distance[i] = int.MaxValue;
        }

        // Bellman-Ford
        bool continueAlg = true; // optimizes the algorithm
        for (int v = 0; v < numberOfNodes - 1 && continueAlg; v++)
        {
            continueAlg = false;
            foreach (var edge in edges)
            {
                if (distance[edge.EndVertex] > distance[edge.StartVertex] + edge.Weight)
                {
                    distance[edge.EndVertex] = distance[edge.StartVertex] + edge.Weight;
                    prevVertex[edge.EndVertex] = edge.StartVertex;
                    continueAlg = true;
                }
            }
        }

        // check for negative cycles
        bool hasNegativeCycle = false;
        for (int i = 0; i < edges.Count && !hasNegativeCycle; i++)
        {
            if (distance[edges[i].EndVertex] > distance[edges[i].StartVertex] + edges[i].Weight)
            {
                hasNegativeCycle = true;
            }
        }

        // print result
        if (hasNegativeCycle)
        {
            Console.WriteLine("Negative cycle");
        }
        else
        {
            PrintPath(distance, prevVertex, numberOfNodes - 1);
            Console.WriteLine();
        }
    }

    private static bool PrintPath(long[] distance, int[] prevVertex, int currentVertex)
    {
        if (currentVertex < 0)
        {
            Console.Write("Could not reach last vertex");
            return false;
        }

        if (currentVertex == 0)
        {
            Console.WriteLine("Value: {0}", distance[distance.Length - 1]);
            Console.Write("Path: 0");
            return true;
        }

        bool canReachLast = PrintPath(distance, prevVertex, prevVertex[currentVertex]);
        if (canReachLast)
        {
            Console.Write(" > {0}", currentVertex);
        }

        return canReachLast;
    }
}