namespace DirectoryTraversal
{
    using System;

    public class TraversalMain
    {
        static void Main()
        {
            ISubDirectoryExtractor subDirectoryExtractor = new SubDirectoryExtractor();
            var traverser = new DirectoryTraverser(@"C:\", subDirectoryExtractor);

            var children = traverser.GetChildDirectories();
            foreach (var child in children)
            {
                Console.WriteLine(child);
            }

            Console.WriteLine(traverser.CurrentDirectory);
        }
    }
}
