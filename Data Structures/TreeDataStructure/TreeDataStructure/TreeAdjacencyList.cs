using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataStructure
{
    public class AdjacencyListTree<T> : ITree<T>
    {
        private int nodesCount;
        
        private List<T> visitedNodes = new List<T>();
        
        public AdjacencyListTree()
        {
            this.nodesCount = 0;
            this.RootNode = null;
        }

        public AdjacencyListTree(TreeNode<T> rootNode)
        {
            this.RootNode = rootNode;
        }
        
        public int NodesCount
        {
            get 
            {
                if (this.RootNode != null)
                {
                    this.nodesCount = 0;
                    this.visitedNodes.Clear();
                    this.CalculateNodesCountDFS(this.RootNode);    
                }
                
                return this.nodesCount; 
            }
        }

        public ITreeNode<T> RootNode { get; set; }

        private void CalculateNodesCountDFS(ITreeNode<T> node)
        {
            if (visitedNodes.Contains(node.NodeName) == false)
            {
                visitedNodes.Add(node.NodeName);
                foreach (var childNode in node.Children)
                {
                    CalculateNodesCountDFS(childNode);
                }

                this.nodesCount++;
            }
        }
    }
}
