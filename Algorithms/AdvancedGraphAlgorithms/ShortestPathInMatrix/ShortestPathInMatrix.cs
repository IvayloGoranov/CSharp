using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//The solution is based on the algorithm solving the "Move Down/Right Sum" problem.
public class ShortestPathInMatrix
{
    private static int[,] matrix;
    private static bool[,] shortestPath;
    private static int rowLength;
    private static int colLength;

    public static void Main()
    {
        ReadMatrix();

        FindShortestPath();
    }

    private static void ReadMatrix()
    {
        rowLength = int.Parse(Console.ReadLine());
        colLength = int.Parse(Console.ReadLine());
        matrix = new int[rowLength, colLength];
        shortestPath = new bool[rowLength, colLength];
        int[][] array = new int[rowLength][]; //To temporarily hold the input values.

        for (int i = 0; i < rowLength; i++) //Input values.
        {
            array[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        for (int rows = 0; rows < rowLength; rows++)
        {
            for (int cols = 0; cols < colLength; cols++)
            {
                matrix[rows, cols] = array[rows][cols]; //The values from the temp jagged array are transfered to the matrix. 
            }
        }
    }

    private static void FindShortestPath() // Calculate sum[,] - the minimum sums of all cells. 
    {
        int[,] sum = new int[rowLength, colLength];
        for (int row = 0; row < rowLength; row++)
        {
            for (int col = 0; col < colLength; col++)
            {
                int minPrevCell = int.MaxValue;
                if (col > 0 && sum[row, col - 1] < minPrevCell)
                {
                    minPrevCell = sum[row, col - 1];
                }

                if (row > 0 && sum[row - 1, col] < minPrevCell)
                {
                    minPrevCell = sum[row - 1, col];
                }

                sum[row, col] = matrix[row, col];

                if (minPrevCell != int.MaxValue)
                {
                    sum[row, col] += minPrevCell;
                }
            }
        }

        BuildShortestPath(sum);
    }

    private static void BuildShortestPath(int[,] sum)
    {
        int row = rowLength - 1;
        int col = colLength - 1;
        while (row >= 0 && col >= 0)
        {
            shortestPath[row, col] = true;
            if (col > 0 && sum[row, col] == sum[row, col - 1] + matrix[row, col])
            {
                col--;
            }
            else
            {
                row--;
            }
        }

        PrintPath();
    }

    private static void PrintPath()
    {
        List<int> path = new List<int>();
        for (int row = 0; row < shortestPath.GetLength(0); row++)
        {
            for (int col = 0; col < shortestPath.GetLength(1); col++)
            {
                if (shortestPath[row, col])
                {
                    path.Add(matrix[row, col]);
                }
            }
        }

        Console.WriteLine("Length: {0}", path.Sum());
        Console.WriteLine("Path: {0}", string.Join(" ", path));
    }
}
