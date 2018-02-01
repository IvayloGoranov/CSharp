namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private IList<T> items;
        
        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IList<T> items)
        {
            this.items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items 
        { 
            get
            {
                return this.items;
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public int BinarySearch(T item)
        {
            int result = this.BinarySearchProcedure(0, this.items.Count - 1, item);

            return result;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = i + rnd.Next(0, this.items.Count - i);
                T temp = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.items));
        }

        private int BinarySearchProcedure(int lowBound, int highBound, T needle)
        {
            if (highBound < lowBound)
            {
                return -1;
            }

            int middle = lowBound + (highBound - lowBound) / 2;

            if (this.items[middle].CompareTo(needle) == 0)
            {
                return middle;
            }
            else if (this.items[middle].CompareTo(needle) > 0)
            {
                return BinarySearchProcedure(lowBound, middle - 1, needle);
            }
            else
            {
                return BinarySearchProcedure(middle + 1, highBound, needle);
            }
        }
    }
}