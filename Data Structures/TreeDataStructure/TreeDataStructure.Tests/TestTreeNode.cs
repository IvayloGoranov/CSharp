using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeDataStructure;
using System.Linq;
using System.Collections.Generic;

namespace TreeDataStructure.Tests
{
    [TestClass]
    public class TestTreeNode
    {
        [TestMethod]
        public void InstantiateTreeNodeWithNodeName_ShouldStoreNodeNameAndHaveNoChildren()
        {

            TreeNode<int> node = new TreeNode<int>(1);
            
            Assert.AreEqual(node.NodeName, 1, "NodeName is not the same as the value provided when creating node.");
            Assert.AreEqual(node.ChildrenCount, 0,
                "Node children count is not zero when creating a node with no children, but it should.");
        }

        [TestMethod]
        public void InstantiateTreeNodeWithNodeNameAndChildren_ShouldStoreNodeNameAndChildren()
        {
            List<ITreeNode<int>> childNodes = new List<ITreeNode<int>>();
            childNodes.Add(new TreeNode<int>(1));
            childNodes.Add(new TreeNode<int>(2));
            childNodes.Add(new TreeNode<int>(3));
            var node = new TreeNode<int>(0, childNodes);

            Assert.AreEqual(node.NodeName, 0, "NodeName is not the same as the value provided when creating node.");
            Assert.AreEqual(node.ChildrenCount, 3,
                "Node children count is not zero when creating a node with no children, but it should.");
        }

        [TestMethod]
        public void InstantiateTreeNodeWithNoChildrenThenAddChild_ShouldStoreNodeNameAndThenChildren()
        {

            TreeNode<int> node = new TreeNode<int>(1);

            Assert.AreEqual(node.NodeName, 1, "NodeName is not the same as the value provided when creating node.");
            Assert.AreEqual(node.ChildrenCount, 0,
                "Node children count is not zero when creating a node with no children, but it should.");

            node.AddNewChild(new TreeNode<int>(2));
            
            Assert.AreEqual(node.ChildrenCount, 1,
                "Node children count is not computed properly.");
        }
    }
}
