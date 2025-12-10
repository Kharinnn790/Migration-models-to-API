using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected AppDbContext DbContext { get; set; }
        public RepositoryBase(AppDbContext dbContext) => DbContext = dbContext;
        public IQueryable<T> FindAll() => DbContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DbContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => DbContext.Set<T>().Add(entity);
        public void Update(T entity) => DbContext.Set<T>().Update(entity);
        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
    }
}
