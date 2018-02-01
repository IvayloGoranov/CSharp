using System.IO;

namespace DirectoryTraversal
{
    public class SubDirectoryExtractor : ISubDirectoryExtractor
    {
        public string[] GetDirectories(string currentDirectory)
        {
            string[] subDirectories = Directory.GetDirectories(currentDirectory);

            return subDirectories;
        }
    }
}
