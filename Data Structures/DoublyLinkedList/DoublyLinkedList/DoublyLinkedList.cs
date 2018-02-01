using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public DoublyLinkedList()
        {
        }
        
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);
                this.tail = this.head;
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.tail = new ListNode<T>(element);
                this.head = this.tail;
            }
            else
            {
                var newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from an emty list!");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from an emty list!");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
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



