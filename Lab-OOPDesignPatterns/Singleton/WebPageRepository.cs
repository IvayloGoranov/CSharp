namespace WebScraper
{
    using System.Collections.Generic;

    public sealed class WebPageRepository
    {
        private static WebPageRepository webPageRepository;

        private static object syncLock = new object();
        
        private Queue<string> addresses;

        public WebPageRepository()
        {
            this.addresses = new Queue<string>();
            this.Seed();
        }

        public static WebPageRepository Instance
        {
            get
            {
                if (webPageRepository == null)
                {
                    lock (syncLock)
                    {
                        if (webPageRepository == null)
                        {
                            webPageRepository = new WebPageRepository();
                        }
                    }
                }

                return webPageRepository;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.addresses.Count == 0;
            }
        }

        public void Add(string address)
        {
            this.addresses.Enqueue(address);
        }

        public string Remove()
        {
            return this.addresses.Dequeue();
        }

        private void Seed()
        {
            this.addresses.Enqueue("https://softuni.bg/");
            this.addresses.Enqueue("http://stackoverflow.com/");
            this.addresses.Enqueue("https://www.youtube.com/");
            this.addresses.Enqueue("https://www.google.bg/");
        }
    }
}
