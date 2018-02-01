public class Edge
{
    public Edge(int start, int end, double distance)
    {
        this.Start = start;
        this.End = end;
        this.Distance = distance;
    }

    public int Start { get; set; }

    public int End { get; set; }

    public double Distance { get; set; }
}
