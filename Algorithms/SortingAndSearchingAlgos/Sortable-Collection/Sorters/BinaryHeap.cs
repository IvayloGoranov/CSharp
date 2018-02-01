namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(IEnumerable<T> elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMax()
        {
            T maxElement = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return maxElement;
        }

        public T PeekMax()
        {
            T maxElement = this.heap[0];

            return maxElement;
        }

        public void Insert(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int parentIndex)
        {
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;
            int largestElementIndex = parentIndex;
            if (leftChildIndex < this.heap.Count
                && this.heap[leftChildIndex].CompareTo(this.heap[largestElementIndex]) > 0)
            {
                largestElementIndex = leftChildIndex;
            }

            if (rightChildIndex < this.heap.Count
                && this.heap[rightChildIndex].CompareTo(this.heap[largestElementIndex]) > 0)
            {
                largestElementIndex = rightChildIndex;
            }

            if (largestElementIndex != parentIndex)
            {
                Swap(parentIndex, largestElementIndex);

                this.HeapifyDown(largestElementIndex);
            }
        }

        private void HeapifyUp(int childIndex)
        {
            int parentIndex = (childIndex - 1) / 2;
            while (childIndex > 0 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) > 0)
            {
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T old = this.heap[firstIndex];
            this.heap[firstIndex] = this.heap[secondIndex];
            this.heap[secondIndex] = old;
        }
    }
}
