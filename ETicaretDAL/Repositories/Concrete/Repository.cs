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
        readonly WebDbContext _dbContext;
        public Repository()
        {
            _dbContext = new WebDbContext();
        }


        #region CRUD Islemleri
        public int Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        #endregion


        #region Select Metodlari
        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);

        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public List<T>? GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbContext.Set<T>().Where(predicate).ToList();
            }
            return _dbContext.Set<T>().ToList();

            //return predicate == null ? _dbContext.Set<T>().ToList() : _dbContext.Set<T>().Where(predicate).ToList();

        }

        public IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate != null)
            {
                query = _dbContext.Set<T>().Where(predicate);
            }
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        #endregion
    }
}
