namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class BubbleSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.BubbleSort(collection);
        }

        private void BubbleSort(IList<T> collection)
        {
            int index = collection.Count - 1;
            while (index > 0)
            {
                for (int i = 0; i < index; i++)
                {
                    if (collection[i].CompareTo(collection[i + 1]) > 0)
                    {
                        this.Swap(collection, i, i + 1);
                    }
                }

                index--;
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
