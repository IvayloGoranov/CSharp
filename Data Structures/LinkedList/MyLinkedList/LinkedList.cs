using System.Collections.Generic;
using System;
using System.Collections;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public LinkedList()
        {
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            var newNode = new ListNode<T>(element);
            if (this.Count == 0)
            {
                this.tail = newNode;
                this.head = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public bool Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from an empty list!");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("Invalid index!");
            }

            if (this.Count > 1)
            {
                ListNode<T> nodeToRemove = this.head;
                int counter = 0;
                while (counter < index && nodeToRemove != null)
                {
                    nodeToRemove = nodeToRemove.NextNode;
                    counter++;
                }

                ListNode<T> previousNode = null;
                ListNode<T> currentNode = this.head;
                while (currentNode != nodeToRemove)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.NextNode;
                }
                
                if (previousNode != null && index != this.Count - 1) //Index is element in the middle.
                {
                    previousNode.NextNode = nodeToRemove.NextNode;
                    nodeToRemove.NextNode = null;
                }
                else if (previousNode == null) //Index is head element.
                {
                    this.head = nodeToRemove.NextNode;
                    nodeToRemove = null;
                }
                else //Index is tail element.
                {
                    previousNode.NextNode = null;
                    this.tail = previousNode;
                }
            }
            else
            {
                this.head = null;
                this.tail = null;
            }

            this.Count--;
            return true;
        }

        public int FirstIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            ListNode<T> currentNode = this.head;
            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return index;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            ListNode<T> currentNode = this.head;
            int currentIndex = 0;
            int foundAtIndex = -1;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    foundAtIndex = currentIndex;
                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            return foundAtIndex;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
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

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currentNode = this.head;
            int index = 0;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }
    }
}
