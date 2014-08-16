using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Attractions.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(  Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        Task<T> GetByIDAsync(object id);
        
        Task InsertAsync(T entity);
       
        Task DeleteAsync(object id);

        Task DeleteAsync(T entityToDelete);

        Task UpdateAsync(T entityToUpdate);
    }
}
