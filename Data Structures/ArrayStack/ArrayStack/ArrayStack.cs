using System;
using System.Collections.Generic;
using System.Collections;

namespace ArrayStack
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            T result = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            T result = this.elements[this.Count - 1];

            return result;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            this.CopyAllElementsTo(array);

            return array;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.elements[i] = default(T);
            }

            this.Count = 0;
        }

        public void TrimExcess()
        {
            T[] trimmedArray = new T[this.Count];
            this.CopyAllElementsTo(trimmedArray);
            this.elements = trimmedArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
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
        }

        private void CopyAllElementsTo(T[] newElements)
        {
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }
        }
    }
}
