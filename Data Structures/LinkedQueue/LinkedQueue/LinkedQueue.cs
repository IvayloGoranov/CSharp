using System;
using System.Collections.Generic;
using System.Collections;

namespace LinkedQueue
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private Node<T> firstNode;
        private Node<T> lastNode;

        public LinkedQueue()
        {
            this.Count = 0;
            this.firstNode = null;
            this.lastNode = null;
        }

        public int Count { get; private set; }
        
        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
                this.lastNode = this.firstNode;
            }
            else
            {
                Node<T> newNode = new Node<T>(element);
                this.lastNode.NextNode = newNode;
                this.lastNode = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T result = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T result = this.firstNode.Value;

            return result;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currentNode = this.firstNode;
            int index = 0;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Clear()
        {
            while (this.firstNode != null)
            {
                this.firstNode = this.firstNode.NextNode;
            }

            this.Count = 0;
        }
    }
}
