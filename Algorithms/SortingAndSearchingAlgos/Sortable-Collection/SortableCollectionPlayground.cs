namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;
    using System.Linq;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter(MaxValue));

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(new QuickSorter<int>());
            Console.WriteLine(collection);

            var collectionToShuflle = new SortableCollection<int>(Enumerable.Range(0, 100).ToArray());
            collectionToShuflle.Shuffle();
            Console.WriteLine(collectionToShuflle);
        }
    }
}
