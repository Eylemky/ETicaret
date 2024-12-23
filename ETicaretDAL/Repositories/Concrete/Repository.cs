using ETicaret.DAL.Repositories.Abstract;
using ETicaret.Entities.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DAL.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly WebDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(WebDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region Temel CRUD islemleri

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Dinamik Sorgular
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? await _dbSet.ToListAsync()
                : await _dbSet.Where(predicate).ToListAsync();
        }
        #endregion

        #region iliski tablolarla birlikte veri çekme
        public async Task<IEnumerable<T>> GetAllIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return predicate == null
                ? await query.ToListAsync()
                : await query.Where(predicate).ToListAsync();
        }
        #endregion
    }
}
