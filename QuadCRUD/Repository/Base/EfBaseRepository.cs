using Microsoft.EntityFrameworkCore;
using QuadCRUD.AppDbContext;

namespace QuadCRUD.Repository.Base
{
    public class EfBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public EfBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<bool> Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            int result = await _context.SaveChangesAsync();
            return IsSaveChangesSuccess(result);
        }
        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return IsSaveChangesSuccess(result);

        }
        public virtual bool Remove(TEntity entity)
        {
            _context.Remove(entity);
            var result = _context.SaveChanges();
            return IsSaveChangesSuccess(result);
        }
        private bool IsSaveChangesSuccess(int entries)
        {
            if (entries > 0)
                return true;
            return false;
        }

    }
}
