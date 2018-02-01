using System;
using System.Collections.Generic;
using System.Linq;

public class Sorting
{
    public static void Main()
    {
       int n = int.Parse(Console.ReadLine());

        int[] initialState = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int k = int.Parse(Console.ReadLine());

        int answer = Bfs(initialState, n, k);
        Console.WriteLine(answer);
    }

    /// <summary>
    /// This method solves the problems using Graph theory and the BFS algorithm
    /// Nodes of the graph are all possible states after reorders with length k
    /// Edges are every possible reorder with length k
    /// </summary>
    private static int Bfs(int[] initialState, int n, int k)
    {
        if (IsSorted(initialState))
        {
            return 0;
        }

        var used = new Dictionary<int, int>(); // Key -> state, Value -> minimum operations to achieve this state
        var queue = new Queue<int[]>();

        queue.Enqueue(initialState);
        used.Add(GetHashCode(initialState), 0);

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();

            // For all possible states from the current (applying allowed operations)
            for (int i = 0; i + k <= n; i++)
            {
                int[] newState = state.Clone() as int[];

                Array.Reverse(newState, i, k);

                if (!used.ContainsKey(GetHashCode(newState)))
                {
                    int operations = used[GetHashCode(state)];
                    if (IsSorted(newState))
                    {
                        return operations + 1;
                    }

                    used.Add(GetHashCode(newState), operations + 1);
                    queue.Enqueue(newState);
                }
            }
        }

        return -1;
    }

    private static int GetHashCode(IEnumerable<int> state)
    {
        int hashCode = 0;
        foreach (var number in state)
        {
            hashCode = (hashCode * 8) + number;
        }

        return hashCode;

        // return state.Aggregate(0, (current, number) => (current * 8) + number);
    }

    private static bool IsSorted(int[] state)
    {
        for (int i = 1; i < state.Length; i++)
        {
            if (state[i] < state[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}
