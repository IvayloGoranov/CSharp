using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal.Tests
{
    internal class FakeSubDirectoryExtractor : ISubDirectoryExtractor
    {
        public string[] GetDirectories(string currentDirectory)
        {
            string[] fakeDirs = new string[] { "C:\\test\\dir3", "C:\\test\\dir1", "C:\\test\\dir2" };

            return fakeDirs;
        }
    }
}
