namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class AStar
    {
        private readonly PriorityQueue<Node> openNodesByFCost;
        private readonly HashSet<Node> closedSet;
        private readonly char[,] map;
        private readonly Node[,] graph;

        public AStar(char[,] map)
        {
            this.map = map;
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];
            this.openNodesByFCost = new PriorityQueue<Node>();
            this.closedSet = new HashSet<Node>();
        }

        public List<int[]> FindShortestPath(int[] startCoords, int[] endCoords)
        {
            Node startNode = this.GetNode(startCoords[0], startCoords[1]);
            Node endNode = this.GetNode(endCoords[0], endCoords[1]);
            startNode.GCost = 0;
            this.openNodesByFCost.Enqueue(startNode);

            while (openNodesByFCost.Count > 0)
            {
                Node currentNode = openNodesByFCost.ExtractMin();
                this.closedSet.Add(currentNode);
                
                if (currentNode.Equals(endNode))
                {
                    break;
                }

                List<Node> neighbours = this.GetNeighbours(currentNode);
                
                foreach (var neighbour in neighbours)
                {
                    if (this.closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int gCost = currentNode.GCost + CalculateGCost(neighbour, currentNode);
                    if (gCost < neighbour.GCost)
                    {
                        neighbour.GCost = gCost;
                        neighbour.Parent = currentNode;

                        if (!this.openNodesByFCost.Contains(neighbour))
                        {
                            neighbour.HCost = CalculateHCost(neighbour, endNode);
                            this.openNodesByFCost.Enqueue(neighbour);
                        }
                        else
                        {
                            this.openNodesByFCost.DecreaseKey(neighbour);
                        }
                    }
                }
            }

            List<int[]> shortestPath = ReconstructPath(endNode);

            return shortestPath;
        }

        private List<int[]> ReconstructPath(Node currentNode)
        {
            List<int[]> cells = new List<int[]>();
            while (currentNode != null)
            {
                cells.Add(new[] { currentNode.Row, currentNode.Col });
                currentNode = currentNode.Parent;
            }

            return cells;
        }

        private int CalculateHCost(Node neighbour, Node endNode)
        {
            return GetDistance(neighbour.Row, neighbour.Col, endNode.Row, endNode.Col);
        }

        private int CalculateGCost(Node neighbour, Node currentNode)
        {
            return GetDistance(neighbour.Row, neighbour.Col, currentNode.Row, currentNode.Col);
        }

        private int GetDistance(int row1, int col1, int row2, int col2)
        {
            int deltaX = Math.Abs(col1 - col2);
            int deltaY = Math.Abs(row1 - row2);

            if (deltaX > deltaY)
            {
                return 14 * deltaY + 10 * (deltaX - deltaY);
            }

            return 14 * deltaX + 10 * (deltaY - deltaX);
        }

        private List<Node> GetNeighbours(Node currentNode)
        {
            var neighbours = new List<Node>();
            int maxRow = this.map.GetLength(0);
            int maxCol = this.map.GetLength(1);

            for (int row = currentNode.Row - 1; row < currentNode.Row + 1; row++)
            {
                if (row < 0 || row >= maxRow)
                {
                    continue;
                }

                for (int col = currentNode.Col - 1; col < currentNode.Col + 1; col++)
                {
                    if (col < 0 || col >= maxCol || this.map[row, col] == 'W')
                    {
                        continue;
                    }

                    Node neighbour = this.GetNode(row, col);
                    if (neighbour.Equals(currentNode))
                    {
                        continue;
                    }

                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        private Node GetNode(int row, int col)
        {
            if (this.graph[row, col] == null)
            {
                this.graph[row, col] = new Node(row, col);
            }

            return this.graph[row, col];
        }
    }
}
