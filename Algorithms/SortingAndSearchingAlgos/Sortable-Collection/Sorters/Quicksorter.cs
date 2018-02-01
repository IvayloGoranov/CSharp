namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    this.Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(collection, start, storeIndex);

            this.QuickSort(collection, start, storeIndex);
            this.QuickSort(collection, storeIndex + 1, end);
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T oldValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldValue;
        }
    }
}
