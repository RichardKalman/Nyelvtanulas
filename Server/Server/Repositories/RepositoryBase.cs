using Microsoft.EntityFrameworkCore;
using Server.Data;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public abstract class RepositoryBase<TEntity>
    {
        protected  readonly DataContext _context;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}