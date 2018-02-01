using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GenericList<T> : IEnumerable<T> where T : IComparable<T>
{
    const int DefaultCapacity = 16;
    private T[] elements;
    private int count = 0;
    public GenericList(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }
    public int Count
    {
        get
        {
            return this.count;
        }
    }
    public void Add(T element)
    {
        if (this.count == this.elements.Length)
        {
            T[] newElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }
        this.elements[this.count] = element;
        this.count++;
    }
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        if (index < this.count - 1)
        {
            for (int i = index; i < this.count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }
        this.count--;
    }
    public void Remove(T element)
    {
        bool elementIsPresent = false;
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(element) == 0)
            {
                for (int j = i; j < this.count - 1; j++)
                {
                    this.elements[j] = this.elements[j + 1];
                }
                this.count--;
                elementIsPresent = true;
            }
        }
        if (elementIsPresent == false)
        {
            throw new ArgumentException(string.Format("Element {0} is not part of the list.", element));
        }
    }
    public int IndexOf(T value)
    {
        int index = -1;
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(value) == 0)
            {
                index = i;
            }
        }
        return index;
    }
    public T Min()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("List is empty!");
        }
        T currentMin = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(currentMin) == -1)
            {
                currentMin = this.elements[i];
            }
        }
        return currentMin;
    }
    public T Max()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("List is empty!");
        }
        T currentMax = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(currentMax) == 1)
            {
                currentMax = this.elements[i];
            }
        }
        return currentMax;
    }
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        this.count++;
        for (int i = count; i > index; i--)
        {
            this.elements[i] = this.elements[i - 1];
        }
        this.elements[index] = element;
    }
    public bool Contains(T value)
    {
        bool doesContain = false;
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(value) == 0)
            {
                doesContain = true;
            }
        }
        return doesContain;
    }
    public void Clear()
    {
        this.count = 0;
    }
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = this.elements[index];
            return result;
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.count; i++)
        {
            yield return this.elements[i];
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public override string ToString()
    {
        GenericList<T> temp = new GenericList<T>();
        for (int i = 0; i < this.count; i++)
        {
            temp.Add(this.elements[i]);
        }
        return string.Join(", ", temp);
    }
}
