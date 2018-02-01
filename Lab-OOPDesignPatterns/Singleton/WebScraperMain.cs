namespace WebScraper
{
    using System;

    public class WebScraperMain
    {
        static void Main()
        {
            var repository = new WebPageRepository();

            var downloader = new Downloader();
            while (!repository.IsEmpty)
            {
                var url = repository.Remove();
                downloader.Download(url, GenerateFileNameFromUrl(url));
            }
        }

        private static string GenerateFileNameFromUrl(string url)
        {
            int afterSlashIndex = url.IndexOf("/", StringComparison.InvariantCulture) + 2;
            int dotIndex = url.LastIndexOf(".", StringComparison.InvariantCulture);

            return string.Format("{0}.html", url.Substring(afterSlashIndex, dotIndex - afterSlashIndex));
        }
    }
}
