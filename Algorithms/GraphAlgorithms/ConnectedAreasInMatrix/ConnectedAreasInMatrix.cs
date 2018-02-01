using System;
using System.Collections.Generic;
using System.Linq;

public class ConnectedAreasInMatrix
{
    private static char[][] matrix;
    private static bool[][] visited;

    public static void Main()
    {
        ReadMatrix();

        Dictionary<char, int> areasCount = new Dictionary<char, int>();

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (!visited[row][col])
                {
                    char currentCellSymbol = matrix[row][col];
                    if (!areasCount.ContainsKey(currentCellSymbol))
                    {
                        areasCount.Add(currentCellSymbol, 0);
                    }

                    areasCount[currentCellSymbol]++;

                    TraverseMatrix(row, col, currentCellSymbol);
                }
            }
        }

        Console.WriteLine("Areas: {0}", areasCount.Values.Sum());
        foreach (var pair in areasCount)
        {
            Console.WriteLine("Letter '{0}' -> {1}", pair.Key, pair.Value);
        }
    }

    private static void TraverseMatrix(int row, int col, char symbol)
    {
        if (!visited[row][col] && matrix[row][col] == symbol)
        {
            visited[row][col] = true;
            if (col > 0)
            {
                TraverseMatrix(row, col - 1, symbol);
            }
            
            if (row > 0)
            {
                TraverseMatrix(row - 1, col, symbol);
            }

            if (col < matrix[row].Length - 1)
            {
                TraverseMatrix(row, col + 1, symbol);
            }

            if (row < matrix.Length - 1)
            {
                TraverseMatrix(row + 1, col, symbol);
            }
        }
    }

    private static void ReadMatrix()
    {
        string[] rowsLengthArgs = Console.ReadLine().Split();
        int rowsLength = int.Parse(rowsLengthArgs[3]);
        matrix = new char[rowsLength][];
        visited = new bool[rowsLength][];
        for (int i = 0; i < rowsLength; i++)
        {
            string rowSymbols = Console.ReadLine();
            matrix[i] = new char[rowSymbols.Length];
            visited[i] = new bool[rowSymbols.Length];
            for (int j = 0; j < rowSymbols.Length; j++)
            {
                matrix[i][j] = rowSymbols[j];
            }
        }
    }
}
