using ETicaret.Entities.Entities.Abstract;
using ETicaretEntity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region Temel CRUD islemleri
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        #endregion
        
        #region Dinamik Sorgular
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        #endregion

        # region iliski tablolarla birlikte veri çekme
        Task<IEnumerable<T>> GetAllIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        #endregion
    }
}
