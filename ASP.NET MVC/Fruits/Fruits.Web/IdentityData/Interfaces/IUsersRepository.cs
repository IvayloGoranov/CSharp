using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fruits.Web.IdentityData.Interfaces
{
    public interface IUsersRepository
    {
        DbSet<User> Set { get; }

        Task<int> Add(User entity);

        Task<int> HardDelete(string id);


        Task<int> HardDelete(User entity);

        Task<User> Find(string id);

        IQueryable<User> GetAll();

        Task<int> Update();
    }
}
