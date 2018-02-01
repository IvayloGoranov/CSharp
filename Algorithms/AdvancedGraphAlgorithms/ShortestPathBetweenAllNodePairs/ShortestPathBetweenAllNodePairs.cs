using System;
using System.Collections.Generic;
using System.Linq;

public class ShortestPathBetweenAllNodePairs
{
    private static int[,] weights; //Adjacency matrix.
    private static List<int>[] edges; //List of edges.
    private static int[,] shortestPaths; //Will hold all shortest paths between all pairs of nodes.
    
    public static void Main()
    {
        Console.Write("Number of nodes = ");
        int nodesCount = int.Parse(Console.ReadLine());
        Console.Write("Number of edges = ");
        int edgesCount = int.Parse(Console.ReadLine());
        
        ReadEdges(edgesCount); //Builds list of edges.
        
        BuildAdjacencyMatrix(nodesCount); //Builds adjacency matrix.
        
        shortestPaths = new int[nodesCount, nodesCount]; //Initializing the result matrix.
        for (int i = 0; i < nodesCount; i++)
        {
            for (int j = 0; j < nodesCount; j++)
            {
                shortestPaths[i, j] = FindShortestPathDijkstra(i, j); //Starting Dijkstra for each pair of nodes
            }                                                         //and recording the distance in the result matrix.  
        }
        
        for (int i = 0; i < nodesCount; i++)
        {
            for (int j = 0; j < nodesCount; j++)
            {
                Console.Write("{0, 3}", shortestPaths[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static int FindShortestPathDijkstra(int startNode, int endNode) //Standard Dijkstra algorithm with weights matrix.
    {
        bool[] visited = new bool[weights.GetLength(0)];
        int[] distanceToStart = new int[weights.GetLength(0)];
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            distanceToStart[i] = int.MaxValue;
        }

        distanceToStart[startNode] = 0;
        int[] predecessor = new int[weights.GetLength(0)];
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            predecessor[i] = -1;
        }
        
        while (true)
        {
            int minDistance = int.MaxValue;
            int minNode = 0;
            for (int node = 0; node < weights.GetLength(0); node++)
            {
                if ((visited[node] == false) && (distanceToStart[node] < minDistance))
                {
                    minDistance = distanceToStart[node];
                    minNode = node;
                }
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }
            
            visited[minNode] = true;
            for (int node = 0; node < weights.GetLength(0); node++)
            {
                if (weights[minNode, node] > 0)
                {
                    minDistance = distanceToStart[minNode] + weights[minNode, node];
                    if (minDistance < distanceToStart[node])
                    {
                        distanceToStart[node] = minDistance;
                        predecessor[node] = minNode;
                    }
                }
            }
        }

        if (distanceToStart[endNode] == int.MaxValue)
        {
            return -1;
        }

        return distanceToStart[endNode];
    }

    private static void ReadEdges(int edgesCount)
    {
        edges = new List<int>[edgesCount];
        for (int i = 0; i < edgesCount; i++)
        {
            edges[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
    }

    private static void BuildAdjacencyMatrix(int nodesCount) //Builds the adjacency matrix.
    {
        weights = new int[nodesCount, nodesCount];
        foreach (var edge in edges)
        {
            weights[edge[0], edge[1]] = edge[2];
            weights[edge[1], edge[0]] = edge[2];
        }
    }
}
