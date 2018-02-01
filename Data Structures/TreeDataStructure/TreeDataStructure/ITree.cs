using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataStructure
{
    public interface ITree<T>
    {
        int NodesCount { get; }
        ITreeNode<T> RootNode { get; }
    }
}
