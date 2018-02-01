using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int InitialCapacity = 16;
    private const float LoadFactor = 0.75f;
    
    private LinkedList<KeyValue<TKey, TValue>>[] slots;
    
    public HashTable(int capacity = InitialCapacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }
    
    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public void Add(TKey key, TValue value)
    {
        if ((float)((this.Count + 1)/this.Capacity) > LoadFactor)
        {
            this.Grow();
        }

        int slotIndex = this.FindSlotIndex(key);
        if (this.slots[slotIndex] == null)
        {
            this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotIndex])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists: " + key);
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotIndex].AddLast(newElement);
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        if ((float)((this.Count + 1) / this.Capacity) > LoadFactor)
        {
            this.Grow();
        }

        int slotIndex = this.FindSlotIndex(key);
        if (this.slots[slotIndex] == null)
        {
            this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotIndex])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotIndex].AddLast(newElement);
        this.Count++;

        return true;
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            throw new KeyNotFoundException("Key does nor exist: " + key);
        }

        return element.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var element = this.Find(key);
        if (element == null)
        {
            value = default(TValue);
            return false;
        }

        value = element.Value;
        return true;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slotIndex = this.FindSlotIndex(key);
        var elements = this.slots[slotIndex];
        if (elements != null)
        {
            foreach (var element in elements)
            {
                if (element.Key.Equals(key))
                {
                    return element;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            return false;
        }

        return true;
    }

    public bool Remove(TKey key)
    {
        int slotIndex = this.FindSlotIndex(key);
        var elements = this.slots[slotIndex];
        if (elements != null)
        {
            var currentElement = elements.First;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    elements.Remove(currentElement);
                    this.Count--;
                    return true;
                }

                currentElement = currentElement.Next;
            }
        }

        return false;
    }

    public void Clear()
    {
        for (int i = 0; i < this.slots.Length; i++)
        {
            this.slots[i] = null;
        }

        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(element => element.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(element => element.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elements in this.slots)
        {
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Grow()
    {
        var newHashTable = new HashTable<TKey, TValue>(2 * this.Capacity);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }

    private int FindSlotIndex(TKey key)
    {
        int slotIndex = Math.Abs(key.GetHashCode()) % this.slots.Length;

        return slotIndex;
    }
}
