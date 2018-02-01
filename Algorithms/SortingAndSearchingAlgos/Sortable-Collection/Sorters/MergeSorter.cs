namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                
                MergeSort(collection, left, middle);
                
                MergeSort(collection, middle + 1, right);
                
                Merge(collection, left, middle, right);
            }
        }

        private void Merge(IList<T> collection, int left, int middle, int right)
        {
            T[] tempArray = new T[right - left + 1];
            int leftMinIndex = left;
            int rightMinIndex = middle + 1;
            int tempIndex = 0;
            
            while (leftMinIndex <= middle && rightMinIndex <= right)
            {
                if (collection[leftMinIndex].CompareTo(collection[rightMinIndex]) < 0)
                {
                    tempArray[tempIndex] = collection[leftMinIndex];
                    tempIndex++;
                    leftMinIndex++;
                }
                else
                {
                    tempArray[tempIndex] = collection[rightMinIndex];
                    tempIndex++;
                    rightMinIndex++;
                }
            }

            while (leftMinIndex <= middle)
            {
                tempArray[tempIndex] = collection[leftMinIndex];
                tempIndex++;
                leftMinIndex++;
            }

            while (rightMinIndex <= right)
            {
                tempArray[tempIndex] = collection[rightMinIndex];
                tempIndex++;
                rightMinIndex++;
            }

            tempIndex = 0;
            leftMinIndex = left;
           
            while (tempIndex < tempArray.Length && leftMinIndex <= right)
            {
                collection[leftMinIndex] = tempArray[tempIndex];
                leftMinIndex++;
                tempIndex++;
            }
        }
    }
}
