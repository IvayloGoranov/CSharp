using CarDealer.Data;

namespace CarDealer.Services
{
    public class Service
    {
        private CarDealerContext context;

        protected Service()
        {
            this.context = new CarDealerContext();
        }

        protected CarDealerContext Context => this.context;
    }
}
