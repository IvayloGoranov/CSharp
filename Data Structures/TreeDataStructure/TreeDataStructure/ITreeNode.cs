using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataStructure
{
    public interface ITreeNode<T>
    {
        T NodeName { get; }
        IEnumerable<ITreeNode<T>> Children { get; }
        int ChildrenCount { get; }
        void AddNewChild (ITreeNode<T> newChildNode);
        void RemoveChild(ITreeNode<T> childNode);
    }
}
