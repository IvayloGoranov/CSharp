using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryTraversal.Tests
{
    [TestClass]
    public class DIrectoryTraverserTests
    {
        [TestMethod]
        public void GetChildDirectories_ShouldReturnDirectoryNames()
        {
            string startDir = "C:\\test";
            ISubDirectoryExtractor fakeSubDirectoryExtractor = new FakeSubDirectoryExtractor();
            DirectoryTraverser dirTraverser = new DirectoryTraverser(startDir, fakeSubDirectoryExtractor);

            var subDirs = dirTraverser.GetChildDirectories().ToArray();
            string[] expectedSubDirs = new string[] { "dir1", "dir2", "dir3" };

            CollectionAssert.AreEqual(subDirs, expectedSubDirs);
        }
    }
}
