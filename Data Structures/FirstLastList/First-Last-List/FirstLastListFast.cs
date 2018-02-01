using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastListFast<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private LinkedList<T> elements;
    private OrderedDictionary<T, List<LinkedListNode<T>>> orderedElements;

    public FirstLastListFast()
    {
        this.elements = new LinkedList<T>();
        this.orderedElements = new OrderedDictionary<T, List<LinkedListNode<T>>>(); 
    }
    
    public void Add(T newElement)
    {
        LinkedListNode<T> newElementNode = this.elements.AddLast(newElement);
        this.orderedElements.AppendValueToKey(newElement, newElementNode);
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("Requested number of elements exceeds the collection count.");
        }
        
        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("Requested number of elements exceeds the collection count.");
        }

        var currentNode = this.elements.Last;
        for (int i = 0; i < count; i++)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Previous;
        }
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("Requested number of elements exceeds the collection count.");
        }

        return this.orderedElements.
            SelectMany(keyValuePair => keyValuePair.Value).
            Select(linkedListNode => linkedListNode.Value).
            Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("Requested number of elements exceeds the collection count.");
        }

        return this.orderedElements.
            Reversed().
            SelectMany(keyValuePair => keyValuePair.Value).
            Select(linkedListNode => linkedListNode.Value).
            Take(count);
    }

    public int RemoveAll(T element)
    {
        if (!this.orderedElements.ContainsKey(element))
        {
            return 0;
        }

        List<LinkedListNode<T>> nodesToRemove = this.orderedElements[element];
        
        this.orderedElements.Remove(element);

        foreach (var node in nodesToRemove)
        {
            this.elements.Remove(node);
        }

        return nodesToRemove.Count;
    }

    public void Clear()
    {
        this.elements.Clear();
        this.orderedElements.Clear();
    }
}
