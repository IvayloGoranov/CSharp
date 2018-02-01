namespace Kruskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            //Initialize parents.
            int[] parent = new int[numberOfVertices];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            List<Edge> spannigTree = new List<Edge>();
            foreach (Edge edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode) //No cyccle
                {
                    spannigTree.Add(edge);
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return spannigTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            //Find the root parent for the node.
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            return root;
        }
    }
}
