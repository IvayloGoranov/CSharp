using CameraBazaar.Data;

namespace CameraBazaar.Services
{
    public class Service
    {
        protected Service()
        {
            this.Context = new CameraBazaarContext();
        }

        protected CameraBazaarContext Context { get; }
    }
}
