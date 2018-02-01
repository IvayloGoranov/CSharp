using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Fruits.Data.Interfaces;
using Fruits.Models;
using Fruits.Services.DTOs;
using Fruits.Services.Interfaces;

namespace Fruits.Services
{
    public class FruitsService : IFruitsService
    {
        private IRepository<Fruit> fruitsRepo;

        public FruitsService(IRepository<Fruit> fruitsRepo)
        {
            this.fruitsRepo = fruitsRepo;
        }

        public virtual async Task<FruitDTO> FindById(int id)
        {
            var resultFruit = await this.fruitsRepo.GetAll()
                                                   .Where(x => x.Id == id)
                                                   .Select(FruitDTO.MapToDTO)
                                                   .FirstOrDefaultAsync();

            if (resultFruit == null)
            {
                throw new KeyNotFoundException(
                    string.Format("No fruit with id {0} was made.", id));
            }

            return resultFruit;
        }

        public virtual async Task<int> Delete(int id)
        {
            var fruit = await this.fruitsRepo.Find(id);

            if (fruit == null)
            {
                throw new KeyNotFoundException(
                    string.Format("No fruit with id {0} was made.", id));
            }

            return await this.fruitsRepo.Delete(fruit);
        }
    }
}
