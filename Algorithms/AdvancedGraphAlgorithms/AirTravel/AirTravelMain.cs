using System;
using System.Collections.Generic;

public class AirTravelMain
{
    public static void Main()
    {
        int numberOfTowns = int.Parse(Console.ReadLine());
        int numberOfFlights = int.Parse(Console.ReadLine());

        var graph = new Dictionary<Node, List<Connection>>();
        var used = new Dictionary<int, Node>();

        for (int i = 0; i < numberOfFlights; i++)
        {
            string[] parts = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int startCity = int.Parse(parts[0]);
            int endCity = int.Parse(parts[1]);
            int departureTime = int.Parse(parts[2]);
            int travellingTime = int.Parse(parts[3]);
            int timeBetweenFilghts = int.Parse(parts[4]);

            // start city
            Node startCityNode;
            if (used.ContainsKey(startCity))
            {
                startCityNode = used[startCity];
            }
            else
            {
                startCityNode = new Node(startCity);
                used.Add(startCity, startCityNode);
                graph.Add(startCityNode, new List<Connection>());
            }

            // end city
            Node endCityNode;
            if (used.ContainsKey(endCity))
            {
                endCityNode = used[endCity];
            }
            else
            {
                endCityNode = new Node(endCity);
                used.Add(endCity, endCityNode);
                graph.Add(endCityNode, new List<Connection>());
            }

            var connection = new Connection(endCityNode, travellingTime, departureTime, timeBetweenFilghts);
            graph[startCityNode].Add(connection);
        }

        int time = int.Parse(Console.ReadLine());

        long min = 1;
        long max = 1000000000;
        long current = 1;
        while (min + 1 < max)
        {
            current = max - ((max - min) / 2);
            if (DijkstraAlgorithm(graph, used[1], used[numberOfTowns], current, time))
            {
                min = current;
            }
            else
            {
                max = current;
            }
        }

        Console.WriteLine(min);
    }

    private static bool DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, 
        Node source, Node end, long safety, int maxTime)
    {
        var queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.DijkstraDistance = long.MaxValue;
        }

        source.DijkstraDistance = 0;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode.DijkstraDistance == long.MaxValue)
            {
                break;
            }

            foreach (var neighbor in graph[currentNode])
            {
                var currentTime = currentNode.DijkstraDistance;
                currentTime += currentNode.Id == 1 ? 1 : safety;

                long waitTime = WaitTime(currentTime, neighbor);
                long potDistance = currentTime + waitTime + neighbor.TravellingTime;
                if (potDistance < neighbor.Node.DijkstraDistance)
                {
                    neighbor.Node.DijkstraDistance = potDistance;
                    queue.Enqueue(neighbor.Node);
                }
            }
        }

        return end.DijkstraDistance <= maxTime;
    }

    private static long WaitTime(long currentTime, Connection flight)
    {
        long departureTime = flight.DepartureTime;
        if (currentTime <= departureTime)
        {
            return departureTime - currentTime;
        }
        else
        {
            currentTime %= flight.Period;
            departureTime %= flight.Period;
            if (currentTime <= departureTime)
            {
                return departureTime - currentTime;
            }
            else
            {
                return departureTime + flight.Period - currentTime;
            }
        }
    }
}
