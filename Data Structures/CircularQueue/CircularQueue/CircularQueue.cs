using System;
using System.Collections;
using System.Collections.Generic;

namespace Circular_Queue
{

    public class CircularQueue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;
        private int startIndex = 0;
        private int endIndex = 0;

        public CircularQueue(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }
        
        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T result = this.elements[this.startIndex];
            this.elements[this.startIndex] = default(T);
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T result = this.elements[this.startIndex];
            
            return result;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            this.CopyAllElementsTo(array);

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[currentIndex];
                currentIndex = (currentIndex + 1) % this.elements.Length;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
        {
            T[] newElements = new T[2 * this.elements.Length];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyAllElementsTo(T[] newElements)
        {
            int sourceIndex = this.startIndex;
            int destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                newElements[destinationIndex] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
                destinationIndex++;
            }
        }
    }
}



