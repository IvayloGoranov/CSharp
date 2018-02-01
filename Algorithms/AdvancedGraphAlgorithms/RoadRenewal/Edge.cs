using System;

public class Edge : IComparable<Edge>
{
    public Edge(int firstNodeId, int secondNodeId, int cost)
    {
        this.FirstNodeId = firstNodeId;
        this.SecondNodeId = secondNodeId;
        this.Cost = cost;
    }

    public int FirstNodeId { get; set; }

    public int SecondNodeId { get; set; }

    public int Cost { get; set; }

    public int CompareTo(Edge otherEdge)
    {
        return this.Cost.CompareTo(otherEdge.Cost);
    }
}
