using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        Dictionary<string, int> predecessorsCount = CalculatePredecessors();

        var removedNodes = new List<string>();
        while (true)
        {
            string nodeToRemove = predecessorsCount.Keys.FirstOrDefault(n => predecessorsCount[n] == 0);
            if (nodeToRemove == null)
            {
                //No more nodes for removal (with zero predecessors).
                break;
            }

            foreach (string childNode in this.graph[nodeToRemove])
            {
                predecessorsCount[childNode]--;
            }
            
            predecessorsCount.Remove(nodeToRemove);
            this.graph.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);
        }

        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph.");
        }

        return removedNodes;
    }

    private Dictionary<string, int> CalculatePredecessors()
    {
        Dictionary<string, int> predecessorsCount = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount[node.Key] = 0;
            }

            foreach (string childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                {
                    predecessorsCount[childNode] = 0;
                }

                predecessorsCount[childNode]++;
            }
        }

        predecessorsCount.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        return predecessorsCount;
    }
}
