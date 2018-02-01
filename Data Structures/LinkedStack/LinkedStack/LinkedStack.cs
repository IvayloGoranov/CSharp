using System;
using System.Collections.Generic;
using System.Collections;

namespace LinkedStack
{
    public class LinkedStack<T> : IEnumerable<T>
    {
        private Node<T> firstNode;

        public LinkedStack()
        {
            this.Count = 0;
            this.firstNode = null;
        }
        
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                this.firstNode = new Node<T>(element, this.firstNode);
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
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
                throw new InvalidOperationException("The stack is empty!");
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

        public void Clear()
        {
            while (this.firstNode != null)
            {
                this.firstNode = this.firstNode.NextNode;
            }

            this.Count = 0;
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
    }
}
