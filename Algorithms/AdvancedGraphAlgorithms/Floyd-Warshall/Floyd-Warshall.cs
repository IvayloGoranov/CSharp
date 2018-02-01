//Computes the shortest paths between all pairs of vertices. Also works with negative edges.

namespace Floyd_Warshall
{
    using System;

    public class FloydWarshallExample
    {
        private const double Inf = double.PositiveInfinity;

        public static void Main()
        {
            var graph = new double[,]
            {
                //0    1    2    3
                { 0,   4,  -2,   Inf },
                { Inf, 0,   3,   -1 },
                { Inf, Inf, 0,   2 },
                { Inf, Inf, Inf, 0 }
            };

            var dist = graph.Clone() as double[,];
            var v = graph.GetLength(0);
            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            Console.WriteLine("Shortest path between (0..3): {0}", dist[0, 3]);
        }
    }
}
