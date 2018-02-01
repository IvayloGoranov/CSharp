using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace MyLinkedList.Tests
{
    [TestClass]
    public class UnitTestsMyLinkedList
    {
        [TestMethod]
        public void Add_EmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            list.Add(5);

            // Assert
            Assert.AreEqual(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void Add_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            list.Add(3);
            list.Add(5);
            list.Add(10);

            // Assert
            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 3, 5, 10 });
        }

        [TestMethod]
        public void Remove_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new LinkedList<int>();
            list.Add(5);

            // Act
            bool isOperationSuccessful = list.Remove(0);

            // Assert
            Assert.AreEqual(true, isOperationSuccessful);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        public void Remove_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(3); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            bool isOperationSuccessful = list.Remove(2);
            Assert.AreEqual(true, isOperationSuccessful);
            Assert.AreEqual(4, list.Count);
            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 1, 2, 4, 5});

            isOperationSuccessful = list.Remove(0);
            Assert.AreEqual(true, isOperationSuccessful);
            Assert.AreEqual(3, list.Count);
            items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 2, 4, 5 });

            isOperationSuccessful = list.Remove(2);
            Assert.AreEqual(true, isOperationSuccessful);
            Assert.AreEqual(2, list.Count);
            items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 2, 4 });

            isOperationSuccessful = list.Remove(1);
            Assert.AreEqual(true, isOperationSuccessful);
            Assert.AreEqual(1, list.Count);
            items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            var element = list.Remove(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_InvalidIndex_ShouldThrowException()
        {
            // Arrange
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(3); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            // Act
            var element = list.Remove(5);
        }

        [TestMethod]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList<int>();
            list.Add(5);

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new LinkedList<string>();
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");

            // Act
            var items = new List<string>();
            list.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_Foreach_MultipleElements()
        {
            // Arrange
            var list = new LinkedList<string>();
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");

            // Act
            var items = new List<string>();
            foreach (var element in list)
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
            var list = new LinkedList<object>();
            list.Add("Five");
            list.Add(6);
            list.Add(7.77);

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
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var list = new LinkedList<string>();

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<string>() { });
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            var list = new LinkedList<string>();
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new string[] { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void FirstIndexOf_SeveralElementsExistingElement_ShouldReturnIndex()
        {
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(2); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            int index = list.FirstIndexOf(2);
            Assert.AreEqual(index, 1);

            index = list.FirstIndexOf(1);
            Assert.AreEqual(index, 0);

            index = list.FirstIndexOf(5);
            Assert.AreEqual(index, 4);
        }

        [TestMethod]
        public void FirstIndexOf_SeveralElementsNonExistingElement_ShouldReturnMinusOne()
        {
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(2); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            int index = list.FirstIndexOf(6);
            Assert.AreEqual(index, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FirstIndexOf_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            int index = list.FirstIndexOf(0);
        }

        [TestMethod]
        public void LastIndexOf_SeveralElementsExistingElement_ShouldReturnIndex()
        {
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(2); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            int index = list.LastIndexOf(2);
            Assert.AreEqual(index, 2);

            index = list.LastIndexOf(1);
            Assert.AreEqual(index, 0);

            index = list.LastIndexOf(5);
            Assert.AreEqual(index, 4);
        }

        [TestMethod]
        public void LastIndexOf_SeveralElementsNonExistingElement_ShouldReturnMinusOne()
        {
            var list = new LinkedList<int>();
            list.Add(1); //index 0
            list.Add(2); //index 1
            list.Add(2); //index 2
            list.Add(4); //index 3
            list.Add(5); //index 4

            int index = list.LastIndexOf(6);
            Assert.AreEqual(index, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LastIndexOf_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            int index = list.LastIndexOf(0);
        }
    }
}
