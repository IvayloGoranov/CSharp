//Shortest path with negative edges.

namespace Bellman_Ford
{
    using System;
    using System.Collections.Generic;

    public class BellmanFordExample
    {
        static void Main()
        {
            int verticeCount = 4;

            var edges = new List<Edge>
            {
                new Edge(3, 1, 15),
                new Edge(3, 2, 2),
                new Edge(2, 1, 12),
                new Edge(1, 0, -5)
            };

            var startNode = 3;
            var destination = 0;

            var distance = FindShortestPathBellmanFord(startNode, destination, verticeCount, edges);
            Console.WriteLine(distance);
        }

        private static int FindShortestPathBellmanFord(int startNode, int destination, int verticeCount, List<Edge> edges)
        {
            var distance = new double[verticeCount];
            var previous = new int[verticeCount];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                previous[i] = -1;
            }

            distance[startNode] = 0;

            for (int i = 0; i < verticeCount - 1; i++)
            {
                foreach (Edge edge in edges)
                {
                    if (distance[edge.Start] + edge.Distance < distance[edge.End])
                    {
                        distance[edge.End] = distance[edge.Start] + edge.Distance;
                        previous[edge.End] = edge.Start;
                    }
                }
            }

            foreach (Edge edge in edges)
            {
                if (distance[edge.Start] + edge.Distance < distance[edge.End])
                {
                    throw new ArgumentException(
                        string.Format("A negative weight cycle exists at edge ({0}, {1})",
                            edge.Start, edge.End
                            ));
                }
            }

            return (int)distance[destination];
        }
    }
}
