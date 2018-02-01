using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataStructure
{
    public class TreeNode<T> : ITreeNode<T>
    {
        private T nodeName;
        private List<ITreeNode<T>> children;
        
        public TreeNode()
        {
            this.nodeName = default(T);
            this.children = new List<ITreeNode<T>>();
        }

        public TreeNode(T nodeName)
        {
            this.nodeName = nodeName;
            this.children = new List<ITreeNode<T>>();
        }

        public TreeNode(T nodeName, List<ITreeNode<T>> childNodes)
        {
            this.nodeName = nodeName;
            this.children = childNodes;
        }

        public T NodeName
        {
            get 
            { 
                return this.nodeName; 
            }
        }

        public IEnumerable<ITreeNode<T>> Children
        {
            get 
            { 
                return this.children; 
            }
        }

        public int ChildrenCount
        {
            get 
            { 
                return this.children.ToArray().Length; 
            }
        }

        public void AddNewChild(ITreeNode<T> newChildNode)
        {
            this.children.Add(newChildNode);
        }

        public void RemoveChild(ITreeNode<T> childNode)
        {
            var childToBeRemoved = this.children.FirstOrDefault(c => c.NodeName.Equals(childNode.NodeName));
            if (childToBeRemoved == null)
            {
                throw new ArgumentException
                    (string.Format("{0} does not have a child node {1}", this.NodeName, childNode.NodeName));
            }

            this.children.Remove(childToBeRemoved);
        }
    }
}
