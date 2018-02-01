using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastListSlow<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
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
            throw new ArgumentOutOfRangeException("count");
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("count");
        }

        return this.elements.Reverse<T>().Take(count);
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("count");
        }

        return this.elements.OrderBy(e => e).Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("count");
        }

        return this.elements.OrderByDescending(e => e).Take(count);
    }

    public int RemoveAll(T element)
    {
        var removedCount =
            this.elements.RemoveAll(e => e.CompareTo(element) == 0);
        return removedCount;
    }

    public void Clear()
    {
        this.elements.Clear();
    }
}
