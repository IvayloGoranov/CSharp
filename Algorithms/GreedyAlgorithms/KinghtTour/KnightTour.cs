namespace Problem_3.Knight_s_Tour
{
    using System;
    using System.Collections.Generic;

    public class KnightTour
    {
        private static int[][] board;

        private static int n;

        private static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            board = new int[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = -1;
                }
            }

            int row = 0;
            int col = 0;
            board[row][col] = 1;

            for (int i = 1; i < n * n; i++)
            {
                List<int[]> moves = FindPossibleMoves(row, col);
                int MinNextMoves = int.MaxValue;
                int index = -1;
                for (int j = 0; j < moves.Count; j++)
                {
                    int[] current = moves[j];
                    int count = FindPossibleMoves(current[0], current[1]).Count;
                    if (count <= MinNextMoves)
                    {
                        MinNextMoves = count;
                        index = j;
                    }
                }

                int[] moveTo = moves[index];
                board[moveTo[0]][moveTo[1]] = i + 1;
                row = moveTo[0];
                col = moveTo[1];
            }

            PrintBoard();
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i][j].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static List<int[]> FindPossibleMoves(int row, int col)
        {
            int[][] movesFromPoint =
                {
                    new[] { row - 2, col - 1 }, new[] { row - 2, col + 1 },
                    new[] { row - 1, col - 2 }, new[] { row + 1, col - 2 },
                    new[] { row + 2, col - 1 }, new[] { row + 2, col + 1 },
                    new[] { row - 1, col + 2 }, new[] { row + 1, col + 2 }
                };

            List<int[]> possibleMoves = new List<int[]>();

            foreach (var move in movesFromPoint)
            {
                if (IsValidMove(move))
                {
                    possibleMoves.Add(move);
                }
            }

            return possibleMoves;
        }

        private static bool IsValidMove(int[] move)
        {
            if (move[0] >= 0 && move[0] < n)
            {
                if (move[1] >= 0 && move[1] < n)
                {
                    if (board[move[0]][move[1]] == -1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}