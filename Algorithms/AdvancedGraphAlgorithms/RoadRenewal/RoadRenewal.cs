using System;
using System.Collections.Generic;

public class RoadRenewal
{
    private static int citiesCount;

    public static void Main()
    {
        citiesCount = int.Parse(Console.ReadLine());

        List<string> paths = new List<string>();
        List<string> builds = new List<string>();
        List<string> destroy = new List<string>();

        for (int i = 0; i < citiesCount; i++)
        {
            paths.Add(Console.ReadLine());
        }

        for (int i = 0; i < citiesCount; i++)
        {
            builds.Add(Console.ReadLine());
        }

        for (int i = 0; i < citiesCount; i++)
        {
            destroy.Add(Console.ReadLine());
        }

        Console.WriteLine(GetCost(paths, builds, destroy));
    }

    private static int GetValue(char character)
    {
        if (character >= 'A' && character <= 'Z')
        {
            return character - 'A';
        }

        return character - 'a' + 26;
    }

    private static int GetCost(List<string> path, List<string> build, List<string> destroy)
    {
        int massiveCost = 0;
        int mstCost = 0;
        // get the cost of each edge + destroy all the existing edges
        List<Edge> edges = new List<Edge>();

        for (int i = 0; i < citiesCount; ++i)
        {
            for (int j = i + 1; j < citiesCount; ++j)
            {
                if (path[i][j] == '0')
                {
                    edges.Add(new Edge(i, j, GetValue(build[i][j])));
                }
                else
                {
                    int destroyValue = GetValue(destroy[i][j]);
                    edges.Add(new Edge(i, j, -destroyValue));
                    massiveCost += destroyValue;
                }
            }
        }

        // solve the MST on the graph, using Kruskal's algorithm
        edges.Sort();

        int[] parentList = new int[citiesCount];
        for (int i = 0; i < citiesCount; ++i)
        {
            parentList[i] = i;
        }

        for (int i = 0; i < edges.Count; ++i)
        {
            Edge edge = edges[i];
            // vertices of the edge are not in the same component
            if (parentList[edge.FirstNodeId] != parentList[edge.SecondNodeId])
            {
                mstCost += edge.Cost;
                // recolor the component
                int oldColor = parentList[edge.SecondNodeId];
                for (int j = 0; j < citiesCount; ++j)
                {
                    if (parentList[j] == oldColor)
                    {
                        parentList[j] = parentList[edge.FirstNodeId];
                    }
                }
            }
        }

        return massiveCost + mstCost;
    }
}
