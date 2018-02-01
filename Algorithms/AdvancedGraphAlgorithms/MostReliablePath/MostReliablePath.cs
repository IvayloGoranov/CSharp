using System;
using System.Collections.Generic;
using System.Linq;

public class MostReliablePath
{
    private static List<int>[] edges; //List of edges.
    private static double[,] weights; //Adjacency matrix.
    private static List<int> shortestPath = new List<int>(); //A list to hold the most reliable path between input start and end node.
    
    public static void Main()
    {
        Console.Write("Number of nodes = ");
        int nodesCount = int.Parse(Console.ReadLine());
        Console.Write("Path: ");
        string[] pathFindInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int startNode = int.Parse(pathFindInfo[0]);
        int endNode = int.Parse(pathFindInfo[2]);
        Console.Write("Number of edges = ");
        int edgesCount = int.Parse(Console.ReadLine());
        
        ReadEdges(edgesCount); //Builds list of edges.
        
        BuildAdjacencyMatrix(nodesCount); //Builds adjacency matrix.
        
        Console.WriteLine("Most reliable path reliability: {0:F2}%", FindShortestPathDijkstra(startNode, endNode));
        Console.WriteLine(string.Join(" -> ", shortestPath));
    }

    private static double FindShortestPathDijkstra(int startNode, int endNode) //Modified Dijkstra algorithm.
    {
        double[] distanceToStart = new double[weights.GetLength(0)];
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            distanceToStart[i] = double.MinValue; //In this version initialy all distances are min infinity.
        }

        distanceToStart[startNode] = 1;
        bool[] visited = new bool[weights.GetLength(0)];
        int[] predecessor = new int[weights.GetLength(0)];
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            predecessor[i] = -1;
        }
        
        while (true)
        {
            double maxDistance = double.MinValue; //In this version we seek the distance with maximum weight value.
            int maxNode = 0;
            for (int node = 0; node < weights.GetLength(0); node++)
            {
                if ((visited[node] == false) && (distanceToStart[node] > maxDistance))
                {
                    maxDistance = distanceToStart[node];
                    maxNode = node;
                }
            }
            
            if (maxDistance == double.MinValue)
            {
                break;
            }

            visited[maxNode] = true;
            for (int node = 0; node < weights.GetLength(0); node++)
            {
                if (weights[maxNode, node] > 0)
                {
                    maxDistance = distanceToStart[maxNode] * weights[maxNode, node];
                    if (maxDistance > distanceToStart[node])
                    {
                        distanceToStart[node] = maxDistance;
                        predecessor[node] = maxNode;
                    }
                }
            }
        }

        if (distanceToStart[endNode] == double.MinValue)
        {
            return -1.0;
        }
        
        BuildPath(predecessor, startNode, endNode); //Builds most reliable path.
        
        return distanceToStart[endNode] * 100;
    }

    private static void BuildPath(int[] predecessor, int startNode, int endNode)
    {
        int currentNode = endNode;
        while (currentNode != startNode)
        {
            shortestPath.Add(currentNode);
            currentNode = predecessor[currentNode];
        }
        shortestPath.Add(startNode);
        shortestPath.Reverse();
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
        weights = new double[nodesCount, nodesCount];
        foreach (var edge in edges)
        {
            weights[edge[0], edge[1]] = edge[2] / (double)100;
            weights[edge[1], edge[0]] = edge[2] / (double)100;
        }
    }
}
