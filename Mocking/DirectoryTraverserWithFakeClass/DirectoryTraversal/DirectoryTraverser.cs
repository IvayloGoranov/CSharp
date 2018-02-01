namespace DirectoryTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraverser
    {
        private ISubDirectoryExtractor subDirectoryExtractor;

        public DirectoryTraverser(string directory, ISubDirectoryExtractor subDirectoryExtractor)
        {
            this.CurrentDirectory = directory;
            this.subDirectoryExtractor = subDirectoryExtractor;
        }

        public string CurrentDirectory { get; set; }

        public IEnumerable<string> GetChildDirectories()
        {
            var directories = subDirectoryExtractor.GetDirectories(this.CurrentDirectory);

            var directoryNames = new List<string>(directories.Length);
            foreach (var directory in directories)
            {
                int lastBackSlash = directory.LastIndexOf("\\");
                string directoryName = directory.Substring(lastBackSlash + 1);

                directoryNames.Add(directoryName);
            }

            directoryNames.Sort();

            return directoryNames;
        }
    }
}
