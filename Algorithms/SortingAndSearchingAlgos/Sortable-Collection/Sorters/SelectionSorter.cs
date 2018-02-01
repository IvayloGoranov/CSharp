namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.SelectionSort(collection);
        }

        private void SelectionSort(IList<T> collection)
        {
            int index = 0;
            while (index < collection.Count - 1)
            {
                int currentMinimum = index;
                for (int j = index + 1; j < collection.Count; j++)
                {
                    if (collection[currentMinimum].CompareTo(collection[j]) > 0)
                    {
                        currentMinimum = j;
                    }
                }

                if (index != currentMinimum)
                {
                    this.Swap(collection, index, currentMinimum);
                }

                index++;
            }
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T oldValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldValue;
        }
    }
}
