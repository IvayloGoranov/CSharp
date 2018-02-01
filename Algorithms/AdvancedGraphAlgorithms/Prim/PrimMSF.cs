using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrimMSF
{
    static List<int>[] adjacencyList = new List<int>[] { 
        new List<int>() {1, 2, 3},
        new List<int>() {0, 3},
        new List<int>() {0, 3, 4},
        new List<int>() {0, 1, 2, 4},
        new List<int>() {2, 3, 5},
        new List<int>() {4},
        new List<int>() {7, 8},
        new List<int>() {6, 8},
        new List<int>() {6, 7},
    };
    static List<int>[] edges = new List<int>[] { 
        new List<int>() {0, 1, 4},
        new List<int>() {0, 2, 5},
        new List<int>() {1, 3, 2},
        new List<int>() {0, 3, 9},
        new List<int>() {2, 3, 20},
        new List<int>() {2, 4, 7},
        new List<int>() {3, 4, 8},
        new List<int>() {4, 5, 12},
        new List<int>() {6, 7, 8},
        new List<int>() {7, 8, 7},
        new List<int>() {6, 8, 10}
    };
    //static string[] nodeNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
    static List<int> traversedNodes = new List<int>();
    static List<Tuple<int, int, int>> priorityQueue = new List<Tuple<int, int, int>>();
    static void Main()
    {
        foreach (var edge in edges)
        {
            if (traversedNodes.Contains(edge[0]) == false)
            {
                Prim(edge[0]);
            }
        }
    }
    static void Prim(int startNode)
    {
        traversedNodes.Add(startNode);
        foreach (var childNode in adjacencyList[startNode])
        {
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i][0] == startNode && edges[i][1] == childNode ||
                    edges[i][1] == childNode && edges[i][0] == startNode)
                {
                    priorityQueue.Add(new Tuple<int, int, int>(edges[i][0], edges[i][1], edges[i][2]));
                    break;
                }
            }
        }

        while (priorityQueue.Count > 0)
        {
            priorityQueue.Sort((x, y) => x.Item3.CompareTo(y.Item3));
            Tuple<int, int, int> smallestEdge = priorityQueue[0];
            priorityQueue.RemoveAt(0);
            if (traversedNodes.Contains(smallestEdge.Item2) == false)
            {
                Console.WriteLine(smallestEdge);
                traversedNodes.Add(smallestEdge.Item2);
                foreach (var childNode in adjacencyList[smallestEdge.Item2])
                {
                    for (int i = 0; i < edges.Length; i++)
                    {
                        if ((edges[i][0] == smallestEdge.Item2 && edges[i][1] == childNode) ||
                            (edges[i][0] == childNode && edges[i][1] == smallestEdge.Item2))
                        {
                            priorityQueue.Add(new Tuple<int, int, int>(edges[i][0], edges[i][1], edges[i][2]));
                            break;
                        }
                    }
                }
            }
        }
    }
}
