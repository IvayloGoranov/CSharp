using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeDataStructure;
using System.Collections.Generic;

namespace TreeDataStructure.Tests
{
    [TestClass]
    public class TestTreeAdjacencyList
    {
        [TestMethod]
        public void InstantiateEmptyTree_ShouldHaveDefaultValueAndNoChildren()
        {

            AdjacencyListTree<int> tree = new AdjacencyListTree<int>();
            Assert.AreEqual(tree.NodesCount, 0, "Nodes count is not zero when creating an empty tree, but it should.");
            Assert.IsNull(tree.RootNode, "Root node is not null when creating an empty tree, but it should.");
        }

        [TestMethod]
        public void InstantiateTreeWithRootAndChildren_ShouldShouldStoreRootAndChildren()
        {
            List<ITreeNode<int>> childNodes = new List<ITreeNode<int>>();
            childNodes.Add(new TreeNode<int>(1));
            childNodes.Add(new TreeNode<int>(2));
            childNodes.Add(new TreeNode<int>(3));
            var node = new TreeNode<int>(0, childNodes);
            var tree = new AdjacencyListTree<int>(node);

            Assert.AreEqual(node.NodeName, 0, "NodeName is not the same as the value provided when creating node.");
            Assert.AreEqual(node.ChildrenCount, 3,
                "Node children count is not zero when creating a node with no children, but it should.");
            
            
            Assert.AreEqual(tree.NodesCount, 4, "Tree NodesCount is not computed properly.");
            Assert.AreEqual(tree.RootNode.NodeName, 0, 
                "Root NodeName is not the same as the value provided when creating node.");
        }

    }
}
