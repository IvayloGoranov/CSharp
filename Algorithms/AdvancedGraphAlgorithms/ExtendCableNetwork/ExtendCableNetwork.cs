using System;
using System.Collections.Generic;
using System.Linq;

public class ExtendCableNetwork
{
    private static List<List<int>> edgesConnected = new List<List<int>>();
    private static List<List<int>> edgesNotConnected = new List<List<int>>();
    private static List<int>[] adjacencyList;
    private static HashSet<int> connectedNodes = new HashSet<int>();
    private static List<Tuple<int, int, int>> priorityQueue = new List<Tuple<int, int, int>>();
    
    public static void Main()
    {
        Console.Write("Budget = ");
        int budget = int.Parse(Console.ReadLine());
        int currentBudgetSpent = 0;
        Console.Write("Number of nodes = ");
        int nodesCount = int.Parse(Console.ReadLine());
        Console.Write("Number of edges = ");
        int edgesCount = int.Parse(Console.ReadLine());
        
        ReadEdges(edgesCount);
        
        BuildAdjacencyList(nodesCount);
        
        foreach (var edge in edgesConnected) 
        {
            if (connectedNodes.Contains(edge[0]) == false)
            {
                connectedNodes.Add(edge[0]);
            }
            
            if (connectedNodes.Contains(edge[1]) == false)
            {
                connectedNodes.Add(edge[1]);
            }
        }

        foreach (int node in connectedNodes) 
        {

            BuildPriorityQueue(node);
        }

        while (priorityQueue.Count != 0) 
        {
            Tuple<int, int, int> smallestEdge = priorityQueue[0];
            priorityQueue.RemoveAt(0);
            if (connectedNodes.Contains(smallestEdge.Item2) == false ||
                    connectedNodes.Contains(smallestEdge.Item1) == false)
            {
                connectedNodes.Add(smallestEdge.Item1);
                connectedNodes.Add(smallestEdge.Item2);
                currentBudgetSpent = smallestEdge.Item3 + currentBudgetSpent;
                if (currentBudgetSpent > budget)
                {
                    currentBudgetSpent = currentBudgetSpent - smallestEdge.Item3;
                    break;
                }

                Console.WriteLine(smallestEdge);
                
                BuildPriorityQueue(smallestEdge.Item1);
                
                BuildPriorityQueue(smallestEdge.Item2);
            }
        }

        Console.WriteLine("Budget used: " + currentBudgetSpent);
    }

    private static void BuildPriorityQueue(int startNode)
    {
        foreach (var childNode in adjacencyList[startNode]) //Traversing the child nodes of the node.
        {
            for (int i = 0; i < edgesNotConnected.Count; i++) //Traversing the not connnected edges.
            {
                if ((edgesNotConnected[i][0] == startNode && edgesNotConnected[i][1] == childNode) || //If such an edge
                    (edgesNotConnected[i][0] == childNode && edgesNotConnected[i][1] == startNode))  //exists.
                {
                    priorityQueue.Add(new Tuple<int, int, int>( //Add it to the priority queue.
                        edgesNotConnected[i][0], edgesNotConnected[i][1], edgesNotConnected[i][2]));
                    break;
                }
            }
        }

        priorityQueue = priorityQueue.Distinct().ToList(); //Remove duplicates from the priority queue. It's possible in the algorithm above.
        
        priorityQueue.Sort((x, y) => x.Item3.CompareTo(y.Item3)); //Sort the tuples by weight value (Item3).
    }

    private static void ReadEdges(int edgesCount)
    {
        List<string> temp = new List<string>(); //To temporarily record input values for further processing.
        for (int i = 0; i < edgesCount; i++)
        {
            temp = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (temp.Contains("connected"))
            {
                temp.Remove("connected");
                //edgesConnected[i] = new List<int>();
                edgesConnected.Add(temp.Select(int.Parse).ToList());
            }
            else
            {
                //edgesConnected[i] = new List<int>();
                edgesNotConnected.Add(temp.Select(int.Parse).ToList());
            }
        }
    }

    private static void BuildAdjacencyList(int nodesCount) //Builds the graph Adjacency List from the lists of edges. 
    {
        adjacencyList = new List<int>[nodesCount];
        for (int i = 0; i < adjacencyList.Length; i++) //Initialising each list in the array.
        {
            adjacencyList[i] = new List<int>();
        }
        
        int index = 0;
        
        for (int i = 0; i < edgesConnected.Count; i++) //Looping the list of edges and recording all desecndants of the node
        {                                               //at position 0 in each array list.
            adjacencyList[edgesConnected[i][index]].Add(edgesConnected[i][index + 1]);
        }
        
        for (int i = 0; i < edgesNotConnected.Count; i++) //Doing the same for the list of edges holding the not connected ones.
        {
            adjacencyList[edgesNotConnected[i][index]].Add(edgesNotConnected[i][index + 1]);
        }
        
        index = 1;
        
        for (int i = 0; i < edgesConnected.Count; i++) //Looping the list of edges and recording all desecndants of the node
        {                                                   //at position 1 in each array list.
            adjacencyList[edgesConnected[i][index]].Add(edgesConnected[i][index - 1]);
        }
        
        for (int i = 0; i < edgesNotConnected.Count; i++)
        {
            adjacencyList[edgesNotConnected[i][index]].Add(edgesNotConnected[i][index - 1]);
        }
    }
}
