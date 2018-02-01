﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circular_Queue;
using System.Collections.Generic;
using System.Collections;

[TestClass]
public class UnitTestsCircularQueue
{
    [TestMethod]
    public void Enqueue_EmptyQueue_ShouldAddElement()
    {
        // Arrange
        var queue = new CircularQueue<int>();

        // Act
        queue.Enqueue(5);

        // Assert
        Assert.AreEqual(1, queue.Count);
    }

    [TestMethod]
    public void EnqueueDeque_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new CircularQueue<string>();
        var element = "some value";

        // Act
        queue.Enqueue(element);
        var elementFromQueue = queue.Dequeue();

        // Assert
        Assert.AreEqual(0, queue.Count);
        Assert.AreEqual(element, elementFromQueue);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
         // Arrange
        var queue = new CircularQueue<int>();

        // Act
        queue.Dequeue();

        // Assert: expect and exception
    }

    [TestMethod]
    public void EnqueueDequeue1000Elements_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new CircularQueue<int>();
        int numberOfElements = 1000;

        // Act
        for (int i = 0; i < numberOfElements; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        for (int i = 0; i < numberOfElements; i++)
        {
            Assert.AreEqual(numberOfElements - i, queue.Count);
            var element = queue.Dequeue();
            Assert.AreEqual(i, element);
            Assert.AreEqual(numberOfElements - i - 1, queue.Count);
        }
    }

    [TestMethod]
    public void CircularQueue_EnqueueDequeueManyChunks_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new CircularQueue<int>();
        int chunks = 100;

        // Act & Assert in a loop
        int value = 1;
        for (int i = 0; i < chunks; i++)
        {
            Assert.AreEqual(0, queue.Count);
            var chunkSize = i + 1;
            for (int counter = 0; counter < chunkSize; counter++)
            {
                Assert.AreEqual(value - 1, queue.Count);
                queue.Enqueue(value);
                Assert.AreEqual(value, queue.Count);
                value++;
            }

            for (int counter = 0; counter < chunkSize; counter++)
            {
                value--;
                Assert.AreEqual(value, queue.Count);
                queue.Dequeue();
                Assert.AreEqual(value - 1, queue.Count);
            }

            Assert.AreEqual(0, queue.Count);
        }
    }

    [TestMethod]
    public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
    {
        // Arrange
        var array = Enumerable.Range(1, 500).ToArray();
        var queue = new CircularQueue<int>();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            queue.Enqueue(array[i]);
        }

        var arrayFromQueue = queue.ToArray();

        // Assert
        CollectionAssert.AreEqual(array, arrayFromQueue);
    }

    [TestMethod]
    public void InitialCapacity1_EnqueueDequeue20Elements_ShouldWorkCorrectly()
    {
        // Arrange
        int elementsCount = 20;
        int initialCapacity = 1;

        // Act
        var queue = new CircularQueue<int>(initialCapacity);
        for (int i = 0; i < elementsCount; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        Assert.AreEqual(elementsCount, queue.Count);
        for (int i = 0; i < elementsCount; i++)
        {
            var elementFromQueue = queue.Dequeue();
            Assert.AreEqual(i, elementFromQueue);
        }

		Assert.AreEqual(0, queue.Count);
    }

    [TestMethod]
    public void IEnumerable_MultipleElements()
    {
        // Arrange
        var queue = new CircularQueue<string>();
        queue.Enqueue("Five");
        queue.Enqueue("Six");
        queue.Enqueue("Seven");

        // Act
        var items = new List<string>();
        foreach (var element in queue)
        {
            items.Add(element);
        }

        // Assert
        CollectionAssert.AreEqual(items,
            new List<string>() { "Five", "Six", "Seven" });
    }

    [TestMethod]
    public void IEnumerable_NonGeneric_MultipleElements()
    {
        // Arrange
        var list = new CircularQueue<object>();
        list.Enqueue("Five");
        list.Enqueue(6);
        list.Enqueue(7.77);

        // Act
        var enumerator = ((IEnumerable)list).GetEnumerator();
        var items = new List<object>();
        while (enumerator.MoveNext())
        {
            items.Add(enumerator.Current);
        }

        // Assert
        CollectionAssert.AreEqual(items, new List<object>() { "Five", 6, 7.77 });
    }

    [TestMethod]
    public void EnqueuePeek_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new CircularQueue<string>();
        var element = "some value";

        // Act
        queue.Enqueue(element);
        var elementFromQueue = queue.Peek();

        // Assert
        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(element, elementFromQueue);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Peek_EmptyQueue_ThrowsException()
    {
        // Arrange
        var queue = new CircularQueue<int>();

        // Act
        queue.Peek();

        // Assert: expect and exception
    }
}
