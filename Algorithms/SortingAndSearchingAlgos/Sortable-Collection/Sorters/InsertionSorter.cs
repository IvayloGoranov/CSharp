namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.InsertionSort(collection);
        }

        private void InsertionSort(IList<T> collection)
        {
            int index = 0;
            while (index < collection.Count - 1)
            {
                for (int i = index + 1; i > 0; i--)
                {
                    if (collection[i].CompareTo(collection[i - 1]) < 0)
                    {
                        T temp = collection[i];
                        collection[i] = collection[i - 1];
                        collection[i - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }

                index++;
            }
        }
    }
}
