using Microsoft.EntityFrameworkCore;

namespace RedditClone.Services
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<Entity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Entity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
