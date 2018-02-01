namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        private List<int>[] buckets;
        private int maxValue;
        
        public BucketSorter(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public void Sort(IList<int> collection)
        {
            this.buckets = new List<int>[collection.Count];
            foreach (var element in collection)
            {
                int bucketIndex = (int)element / this.maxValue * collection.Count;
                if (this.buckets[bucketIndex] == null)
                {
                    this.buckets[bucketIndex] = new List<int>();
                }

                this.buckets[bucketIndex].Add(element);
            }

            var quickSorter = new QuickSorter<int>();

            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    quickSorter.Sort(bucket);
                }
            }

            int index = 0;
            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        collection[index] = item;
                        index++;
                    }
                }
            }
        }

        
    }
}
