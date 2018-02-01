using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kruskal
{
    private static List<int>[] adjacencyList = new List<int>[] { 
    new List<int>() {3, 5, 8},
    new List<int>() {4, 7},
    new List<int>() {6},
    new List<int>() {0, 5, 6, 8},
    new List<int>() {1, 7},
    new List<int>() {0, 3},
    new List<int>() {2, 3, 8},
    new List<int>() {1, 4},
    new List<int>() {0, 3, 6},
    };

    private static List<int>[] edges = new List<int>[] { 
    new List<int>() {0, 3, 9},
    new List<int>() {0, 5, 4},
    new List<int>() {0, 8, 5},
    new List<int>() {3, 5, 2},
    new List<int>() {3, 8, 20},
    new List<int>() {3, 6, 8},
    new List<int>() {6, 8, 7},
    new List<int>() {2, 6, 12},
    new List<int>() {1, 4, 8},
    new List<int>() {1, 7, 7},
    new List<int>() {4, 7, 10}
    };

    public static void Main()
    {
        edges = edges.OrderBy(list => list[2]).ToArray();
        int[] parentList = new int[adjacencyList.Length];
        for (int i = 0; i < parentList.Length; i++)
        {
            parentList[i] = i;
        }

        List<Tuple<int, int, int>> spanningTree = new List<Tuple<int, int, int>>();
        
        foreach (var edge in edges)
        {
            int rootNode1 = FindRootParent(edge[0], parentList);
            int rootNode2 = FindRootParent(edge[1], parentList);
            if (rootNode1 != rootNode2)
            {
                spanningTree.Add(new Tuple<int, int, int>(edge[0], edge[1], edge[2]));
                parentList[rootNode2] = rootNode1;
            }
        }
        
        foreach (var edge in spanningTree)
        {
            Console.WriteLine(edge);
        }
    }

    private static int FindRootParent(int node, int[] parentList)
    {
        while (parentList[node] != node)
        {
            node = parentList[node];
        }

        return node;
    }
}
