namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var heap = new BinaryHeap<T>(collection);
            int index = collection.Count - 1;
            while (heap.Count != 0)
            {
                var item = heap.ExtractMax();
                collection[index] = item;
                index--;
            }
        }
    }
}
