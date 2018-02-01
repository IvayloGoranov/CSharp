using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Salaries
{
    static List<int>[] graph;
    static bool[] visited; //To keep track of visited nodes.
    static int[] salaries; //To hold the salary of each employee.

    static void Main()
    {
        ReadGraph();
        
        for (int node = 0; node < graph.Length; node++) //Traversing the graph, if a node has no successors, 
        {                                               //this employee has salary 1.
            if (graph[node].Count == 0)
            {
                salaries[node] = 1;
            }
        }

        int[] predecessorsCount = new int[graph.Length]; //To track predecessors.
        for (int node = 0; node < graph.Length; node++)
        {
            foreach (var childNode in graph[node])
            {
                predecessorsCount[childNode]++;
            }
        }

        for (int node = 0; node < graph.Length; node++)
        {
            if (predecessorsCount[node] > 0)
            {
                continue;
            }

            CalcSalariesDFS(node); //The graph tarversal will start only from nodes without predecessors.
        }

        Console.WriteLine(salaries.Sum()); //Printing the total amount of salaries, the sum of all individual salaries.
    }

    static void ReadGraph()
    {
        int graphLength = int.Parse(Console.ReadLine());
        graph = new List<int>[graphLength];
        visited = new bool[graphLength];
        salaries = new int[graphLength];
        
        for (int node = 0; node < graph.Length; node++)
        {
            string childNodesArgs = Console.ReadLine();
            graph[node] = new List<int>();
            for (int nodeValue = 0; nodeValue < childNodesArgs.Length; nodeValue++)
            {
                if (childNodesArgs[nodeValue] == 'Y')
                {
                    graph[node].Add(nodeValue);
                }
            }
        }
    }

    static void CalcSalariesDFS(int employee) //A standard DFS algorithm with a minor adjustment to calculate salaries.
    {
        if (visited[employee] == false)
        {
            visited[employee] = true;
            foreach (var childNode in graph[employee])
            {
                CalcSalariesDFS(childNode);
            }

            foreach (var childNode in graph[employee])
            {
                salaries[employee] = salaries[employee] + salaries[childNode];
            }
        }
    }
}
