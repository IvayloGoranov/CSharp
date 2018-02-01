using System;
using System.Collections.Generic;
using System.Linq;

public class PrimPriorityQueue
{
    private static List<Edge> edges = new List<Edge>()
    {
        new Edge("C", "D", 20),
        new Edge("D", "B", 2),
        new Edge("D", "E", 8),
        new Edge("I", "H", 7),
        new Edge("B", "A", 4),
        new Edge("C", "E", 7),
        new Edge("G", "H", 8),
        new Edge("I", "G", 10),
        new Edge("A", "D", 9),
        new Edge("E", "F", 12),
        new Edge("C", "A", 5)
    };

    public static void Main()
    {
        var graph = BuildGraph();
        var spanningTreeNodes = new HashSet<string>();
        var spannngTreeEdges = new List<Edge>();

        // Start Prim's algorithm from each node not still in the spanning tree
        foreach (var startNode in graph.Keys)
        {
            if (!spanningTreeNodes.Contains(startNode))
            {
                Prim(graph, spanningTreeNodes, startNode, spannngTreeEdges);
            }
        }

        Console.WriteLine("Minimum spanning forest weight: " +
            spannngTreeEdges.Sum(e => e.Weight));

        foreach (var edge in spannngTreeEdges)
        {
            Console.WriteLine(edge);
        }
    }

    private static void Prim(Dictionary<string, List<Edge>> graph,
        HashSet<string> spanningTreeNodes, string startNode,
        List<Edge> spannngTreeEdges)
    {
        spanningTreeNodes.Add(startNode);
        var priorityQueue = new BinaryHeap<Edge>();
        foreach (var edge in graph[startNode])
        {
            priorityQueue.Enqueue(edge);
        }

        while (priorityQueue.Count > 0)
        {
            var smallestEdge = priorityQueue.ExtractMin();
            if (spanningTreeNodes.Contains(smallestEdge.StartNode) ^
                spanningTreeNodes.Contains(smallestEdge.EndNode))
            {
                var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode)
                    ? smallestEdge.EndNode
                    : smallestEdge.StartNode;
                spannngTreeEdges.Add(smallestEdge);
                spanningTreeNodes.Add(nonTreeNode);

                foreach (Edge newEdge in graph[nonTreeNode])
                {
                    if (newEdge != smallestEdge)
                    {
                        priorityQueue.Enqueue(newEdge);
                    }
                }
            }
        }
    }

    static Dictionary<string, List<Edge>> BuildGraph()
    {
        var graph = new Dictionary<string, List<Edge>>();
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge.StartNode))
            {
                graph.Add(edge.StartNode, new List<Edge>());
            }

            graph[edge.StartNode].Add(edge);
            if (!graph.ContainsKey(edge.EndNode))
            {
                graph.Add(edge.EndNode, new List<Edge>());
            }

            graph[edge.EndNode].Add(edge);
        }

        return graph;
    }
}
