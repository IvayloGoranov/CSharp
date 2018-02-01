namespace ShortestPathsWithNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPathsWithNegativeEdges
    {
        public static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string[] arguments = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int source = int.Parse(arguments[1]);
            int destination = int.Parse(arguments[3]);
            int edgeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < edgeCount; i++)
            {
                int[] edgeParams =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var edge = new Edge(edgeParams[0], edgeParams[1], edgeParams[2]);
                edges.Add(edge);
            }

            int[] distance = new int[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                distance[i] = int.MaxValue;
            }
            int?[] previous = new int?[nodeCount];
            distance[source] = 0;

            for (int i = 1; i < nodeCount; i++)
            {
                foreach (var edge in edges)
                {
                    if (distance[edge.StartNode] != int.MaxValue && distance[edge.EndNode] > distance[edge.StartNode] + edge.Weight)
                    {
                        distance[edge.EndNode] = distance[edge.StartNode] + edge.Weight;
                        previous[edge.EndNode] = edge.StartNode;
                    }
                }
            }

            int? negativeNode = null; 
            foreach (var edge in edges)
            {
                if (distance[edge.EndNode] > distance[edge.StartNode] + edge.Weight)
                {
                    negativeNode = edge.StartNode;
                    break;
                }
            }

            if (negativeNode != null)
            {
                List<int> path = new List<int>();
                path.Add(negativeNode.Value);
                int? node = previous[negativeNode.Value];
                while (node != null && negativeNode != node)
                {
                    path.Add(node.Value);
                    node = previous[node.Value];
                }
                path.Reverse();
                Console.WriteLine("Negative cycle detected: {0}", string.Join(" -> ", path));
            }
            else
            {
                List<int> path = new List<int>();
                int? current = destination;

                while (current != null)
                {
                    path.Add(current.Value);
                    current = previous[current.Value];
                }
                path.Reverse();

                Console.WriteLine("Distance [{0} -> {1}]: {2}", source, destination, distance[destination]);
                Console.WriteLine("Path: {0}", string.Join(" -> ", path));
            }
        }
    }
}
