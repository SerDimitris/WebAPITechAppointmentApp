
using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TechAppointmentAppDbContext _context;
        private readonly DbSet<T> _dbset;

        public BaseRepository(TechAppointmentAppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual async Task AddAsync(T entity) => await _dbset.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbset.AddRangeAsync(entities);

        public virtual void UpdateAsync(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            T? existingEntity = await _dbset.FindAsync(id);
            if (existingEntity is null) return false;
            _dbset.Remove(existingEntity);
            return true;
        }

        public virtual async Task<T?> GetAsync(int id) => await _dbset.FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbset.ToListAsync();

        public virtual async Task<int> GetCountAsync() => await _dbset.CountAsync();
    }
}