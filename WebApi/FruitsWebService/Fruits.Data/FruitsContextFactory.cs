using System.Data.Entity.Infrastructure;

namespace Fruits.Data
{
    public class FruitsContextFactory : IDbContextFactory<FruitsContext>
    {
        public FruitsContext Create()
        {
            return new FruitsContext("Server=(localdb)\\mssqllocaldb;Database=FruitsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
