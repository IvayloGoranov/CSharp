using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    public interface ISubDirectoryExtractor
    {
        string[] GetDirectories(string currentDirectory);
    }
}
