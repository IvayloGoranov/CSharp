using System;
using System.Collections.Generic;

public class SticksMain
{
    private static IDictionary<int, Node> graph = new SortedDictionary<int, Node>(
        Comparer<int>.Create((a, b) => -a.CompareTo(b)));

    public static void Main()
    {
        int sticksCount = int.Parse(Console.ReadLine()); //Number of graph nodes.
        int placingsCount = int.Parse(Console.ReadLine()); //Number of graph edges.
        GenerateGraphFromSticks(sticksCount, placingsCount);

        RemoveSticks();
    }

    private static void RemoveSticks()
    {
        bool[] isRemoved = new bool[graph.Count];
        List<int> removedNodes = new List<int>();
        bool nodeRemoved = true;
        while (nodeRemoved)
        {
            nodeRemoved = false;
            foreach (var pair in graph)
            {
                var node = pair.Value;
                if (node.PredecessorsCount == 0)
                {
                    // Found a stick with 0 sticks above it -> remove it from the graph
                    foreach (var childNode in node.Successors)
                    {
                        childNode.PredecessorsCount--;
                    }

                    removedNodes.Add(node.NodeValue);
                    nodeRemoved = true;
                    break;
                }
            }

            graph.Remove(removedNodes[removedNodes.Count - 1]); //Remove from graph last node added to removedNodes list.
        }

        if (graph.Count == 0)
        {
            Console.WriteLine(string.Join(" ", removedNodes));
        }
        else
        {
            Console.WriteLine("Cannot lift all sticks");
            Console.WriteLine(string.Join(" ", removedNodes));
        }
    }

    private static void GenerateGraphFromSticks(int sticksCount, int placingsCount)
    {
        for (int nodeValue = 0; nodeValue < sticksCount; nodeValue++)
        {
            graph.Add(nodeValue, new Node(nodeValue));
        }

        for (int i = 0; i < placingsCount; i++)
        {
            string[] currentEdgeArgs = Console.ReadLine().Split();
            int firstNodeValue = int.Parse(currentEdgeArgs[0]);
            int secondNodeValue = int.Parse(currentEdgeArgs[1]);

            graph[firstNodeValue].Successors.Add(graph[secondNodeValue]);
            graph[secondNodeValue].PredecessorsCount++;
        }
    }
}