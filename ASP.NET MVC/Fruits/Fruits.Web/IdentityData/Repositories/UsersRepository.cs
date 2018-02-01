using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Fruits.Web.IdentityData.Interfaces;

namespace Fruits.Web.IdentityData.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private IAppIdentityDbContext context;
        private DbSet<User> dbSet;

        public UsersRepository(IAppIdentityDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<User>();
        }

        public DbSet<User> Set
        {
            get
            {
                return this.dbSet;
            }
        }

        public virtual async Task<int> Add(User entity)
        {
            this.Set.Add(entity);

            return await this.context.SaveChangesAsync(default(CancellationToken));
        }

        public virtual async Task<int> HardDelete(string id)
        {
            var entityToDelete = await this.Find(id);

            return await this.HardDelete(entityToDelete);
        }


        public virtual async Task<int> HardDelete(User entity)
        {
            this.Set.Remove(entity);

            return await this.context.SaveChangesAsync(default(CancellationToken));
        }

        public virtual async Task<User> Find(string id)
        {
            return await this.Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual IQueryable<User> GetAll()
        {
            return this.Set;
        }

        public virtual async Task<int> Update()
        {
            return await this.context.SaveChangesAsync(default(CancellationToken));
        }
    }
}
