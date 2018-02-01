using System;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public Node(int nodeValue)
    {
        this.NodeValue = nodeValue;
        this.Successors = new SortedSet<Node>();
    }

    public int NodeValue { get; set; }

    public SortedSet<Node> Successors { get; set; }

    public int PredecessorsCount { get; set; }

    public int CompareTo(Node otherNode)
    {
        return -this.NodeValue.CompareTo(otherNode.NodeValue);
    }

    public override string ToString()
    {
        return this.NodeValue.ToString();
    }
}
