using System;

public class Node : IComparable
{
    public Node(int id)
    {
        this.Id = id;
    }

    public int Id { get; private set; }

    public bool IsWatched { get; set; }

    public int EnergyWaisted { get; set; }

    public int DijkstraDistance { get; set; }

    public Node Previous { get; set; }

    public void UpdateCamera()
    {
        if (this.IsWatched)
        {
            this.IsWatched = false;
        }
        else
        {
            this.IsWatched = true;
        }
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Node))
        {
            return -1;
        }

        return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
    }
}