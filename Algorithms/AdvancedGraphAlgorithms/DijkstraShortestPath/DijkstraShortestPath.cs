using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DijkstraShortestPath
{
    private static int[,] weights = new int[,] { 
        // 0   1   2   3   4   5   6   7   8   9  10  11
         { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
         { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
         { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
         { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
         { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
         { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
         {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
         { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
         {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
         { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
         { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
         { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
    };
    
    private static List<int> shortestPath = new List<int>();
    
    public static void Main()
    {
        Console.WriteLine("Shortest Distance: " + FindShortestPathDijkstra(0, 9));
        Console.WriteLine("Shortest Path = " + string.Join(", ", shortestPath));
    }
    
    private static int FindShortestPathDijkstra(int startNode, int endNode)
    {
        int[] distanceToStart = new int[weights.GetLength(0)];
        for (int i = 0; i < distanceToStart.Length; i++)
        {
            distanceToStart[i] = int.MaxValue;
        }
        
        distanceToStart[startNode] = 0;

        bool[] visited = new bool[weights.GetLength(0)];
        
        int[] predecessor = new int[weights.GetLength(0)];
        for (int i = 0; i < predecessor.Length; i++)
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

        BuildPath(predecessor, startNode, endNode);
        
        return distanceToStart[endNode];
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
}
