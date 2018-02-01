using System;
using System.Collections.Generic;

public class RobberyMain
{
    private static Dictionary<int, Node> nodes = new Dictionary<int, Node>();
    private static Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
    private static int startEnergy;
    private static int waitingCost;

    public static void Main()
    {
        string[] nodeValues = Console.ReadLine().Split();
        ReadNodes(nodeValues);

        startEnergy = int.Parse(Console.ReadLine());
        waitingCost = int.Parse(Console.ReadLine());
        int startingNode = int.Parse(Console.ReadLine());
        int endingNode = int.Parse(Console.ReadLine());
        int edgesCount = int.Parse(Console.ReadLine());

        BuildGraph(edgesCount);

        DijkstraAlgorithm(startingNode, endingNode);

        int endEnergy = CalculateEnergy(endingNode);
        if (endEnergy <= 0)
        {
            Console.WriteLine("Busted - need {0} more energy", Math.Abs(endEnergy - startEnergy));
        }
        else
        {
            Console.WriteLine(endEnergy);
        }
    }

    private static void DijkstraAlgorithm(int startingNode, int endingNode)
    {
        var queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.DijkstraDistance = int.MaxValue;
        }

        Node start = nodes[startingNode];
        start.DijkstraDistance = 0;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode.DijkstraDistance == int.MaxValue)
            {
                break;
            }

            foreach (var neighbor in graph[currentNode])
            {
                int minDistance = currentNode.DijkstraDistance + neighbor.Distance;
                if (neighbor.Node.IsWatched)
                {
                    minDistance = minDistance + waitingCost;
                }

                if (minDistance < neighbor.Node.DijkstraDistance)
                {
                    neighbor.Node.DijkstraDistance = minDistance;
                    neighbor.Node.Previous = currentNode;
                    queue.Enqueue(neighbor.Node);
                }
            }

            foreach (var pair in nodes)
            {
                pair.Value.UpdateCamera();
            }
        }
    }

    private static void ReadNodes(string[] nodeValues)
    {
        for (int i = 0; i < nodeValues.Length; i++)
        {
            int nodeValue = int.Parse(nodeValues[i].Substring(0, nodeValues[i].Length - 1).ToString());
            Node newNode = new Node(nodeValue);
            bool isWatched = nodeValues[i][nodeValues[i].Length - 1].Equals('w');
            newNode.IsWatched = isWatched;
            if (!nodes.ContainsKey(nodeValue))
            {
                nodes.Add(nodeValue, newNode);
            }
        }
    }

    private static void BuildGraph(int edgesCount)
    {
        for (int i = 0; i < edgesCount; i++)
        {
            string[] edgeArgs = Console.ReadLine().Split();
            int startNodeValue = int.Parse(edgeArgs[0]);
            int endNodeValue = int.Parse(edgeArgs[1]);
            int distance = int.Parse(edgeArgs[2]);

            Node start = nodes[startNodeValue];
            Node end = nodes[endNodeValue];
            if (!graph.ContainsKey(start))
            {
                graph.Add(start, new List<Connection>());
            }

            if (!graph.ContainsKey(end))
            {
                graph.Add(end, new List<Connection>());
            }

            Connection connection = new Connection(end, distance);
            graph[start].Add(connection);
        }
    }

    private static int CalculateEnergy(int endNode)
    {
        int endEnergy = startEnergy;
        Node currentNode = nodes[endNode];
        while (currentNode != null)
        {
            endEnergy = endEnergy - currentNode.DijkstraDistance;
            currentNode = currentNode.Previous;
        }

        return endEnergy;
    }
}
