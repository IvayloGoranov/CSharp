using System;
using System.Collections.Generic;

public class DictionaryGraph
{
    static Dictionary<string, List<string>> graph =
        new Dictionary<string, List<string>>() {
            { "Sofia", new List<string>() {
                "Plovdiv", "Varna", "Bourgas", "Pleven", "Stara Zagora" } },
            { "Plovdiv", new List<string>() {
                "Bourgas", "Ruse" } },
            { "Varna", new List<string>() {
                "Ruse", "Stara Zagora" } },
            { "Bourgas", new List<string>() {
                "Plovdiv", "Pleven" } },
            { "Ruse", new List<string>() {
                "Varna", "Plovdiv" } },
            { "Pleven", new List<string>() {
                "Bourgas", "Stara Zagora" } },
            { "Stara Zagora", new List<string>() {
                "Varna", "Pleven" } },
        };

    public static void Main()
    {
        //graph = ReadGraph();

        PrintGraph(graph);
    }

    static Dictionary<string, List<string>> ReadGraph()
    {
        var graph = new Dictionary<string, List<string>>();

        // Read a sequence of edges {parent, child} until an empty line is entered
        string line = Console.ReadLine();
        while (line != string.Empty)
        {
            string[] edge = line.Split(' ');

            string parent = edge[0];
            string child = edge[1];

            if (!graph.ContainsKey(parent))
            {
                graph[parent] = new List<string>();
            }

            graph[parent].Add(child);

            if (parent != child)
            {
                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<string>();
                }

                graph[child].Add(parent);
            }

            line = Console.ReadLine();
        }

        return graph;
    }

    static void PrintGraph(Dictionary<string, List<string>> graph)
    {
        foreach (var node in graph)
        {
            Console.WriteLine("{0} -> {1}",
                node.Key,
                string.Join(", ", node.Value));
        }
    }
}
