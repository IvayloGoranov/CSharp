
public class Edge
{
    public Edge(int startVertex, int endVertex, int weight)
    {
        this.StartVertex = startVertex;
        this.EndVertex = endVertex;
        this.Weight = weight;
    }

    public int StartVertex { get; set; }

    public int EndVertex { get; set; }

    public int Weight { get; set; }
}
