using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedStack;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LinkedStack.Tests
{
    [TestClass]
    public class UnitTestsLinkedStack
    {
        [TestMethod]
        public void Push_EmptyStack_ShouldAddElement()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Push(5);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushPop_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<string>();
            var element = "some value";

            // Act
            stack.Push(element);
            var elementFromStack = stack.Pop();

            // Assert
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(element, elementFromStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ThrowsException()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Pop();

            // Assert: expect an exception
        }

        [TestMethod]
        public void PushPop1000Elements_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
            int numberOfElements = 1000;

            // Act
            for (int i = 1; i <= numberOfElements; i++)
            {
                stack.Push(i);
            }

            // Assert
            for (int i = numberOfElements, j = 0; i >= 1; i--, j++)
            {
                Assert.AreEqual(numberOfElements - j, stack.Count);
                var element = stack.Pop();
                Assert.AreEqual(i, element);
                Assert.AreEqual(numberOfElements - j - 1, stack.Count);
            }
        }

        [TestMethod]
        public void PushPopManyChunks_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
            int chunks = 100;

            // Act & Assert in a loop
            int value = 1;
            for (int i = 0; i < chunks; i++)
            {
                Assert.AreEqual(0, stack.Count);
                var chunkSize = i + 1;
                for (int counter = 0; counter < chunkSize; counter++)
                {
                    Assert.AreEqual(value - 1, stack.Count);
                    stack.Push(value);
                    Assert.AreEqual(value, stack.Count);
                    value++;
                }

                for (int counter = 0; counter < chunkSize; counter++)
                {
                    value--;
                    Assert.AreEqual(value, stack.Count);
                    stack.Pop();
                    Assert.AreEqual(value - 1, stack.Count);
                }

                Assert.AreEqual(0, stack.Count);
            }
        }

        [TestMethod]
        public void Push500Elements_ToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 500).ToArray();
            var stack = new LinkedStack<int>();

            // Act
            for (int i = array.Length - 1; i >= 0; i--)
            {
                stack.Push(array[i]);
            }

            var arrayFromStack = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromStack);
        }

        [TestMethod]
        public void IEnumerable_MultipleElements()
        {
            // Arrange
            var stack = new LinkedStack<string>();
            stack.Push("Five");
            stack.Push("Six");
            stack.Push("Seven");

            // Act
            var items = new List<string>();
            foreach (var element in stack)
            {
                items.Add(element);
            }

            // Assert
            CollectionAssert.AreEqual(items,
                new List<string>() { "Seven", "Six", "Five" });
        }

        [TestMethod]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            // Arrange
            var stack = new LinkedStack<object>();
            stack.Push("Five");
            stack.Push(6);
            stack.Push(7.77);

            // Act
            var enumerator = ((IEnumerable)stack).GetEnumerator();
            var items = new List<object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(items, new List<object>() { 7.77, 6, "Five" });
        }

        [TestMethod]
        public void PushPeek_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<string>();
            var element = "some value";

            // Act
            stack.Push(element);
            var elementFromStack = stack.Peek();

            // Assert
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(element, elementFromStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ThrowsException()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Peek();

            // Assert: expect an exception
        }

        [TestMethod]
        public void Clear_StackWithElememnts_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Clear();

            // Assert
            Assert.AreEqual(0, stack.Count);
        }
    }
}
