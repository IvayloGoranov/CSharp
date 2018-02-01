using System.Threading.Tasks;

using Fruits.Services.DTOs;

namespace Fruits.Services.Interfaces
{
    public interface IFruitsService
    {
        Task<FruitDTO> FindById(int id);

        Task<int> Delete(int id);
    }
}
