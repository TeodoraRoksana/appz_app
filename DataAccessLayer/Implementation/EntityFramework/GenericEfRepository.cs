using DataAccessLayer.Interface;
using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Implementation.EntityFramework
{
    public class GenericEfRepository<T> : IGenericRepository<T> where T : class, IBaseModel
    {
        protected MedAppDbContext _appContext;

        public GenericEfRepository(MedAppDbContext context)
        {
            _appContext = context;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _appContext.Set<T>().ToListAsync()).AsQueryable();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return (await _appContext.Set<T>().Where(condition).ToListAsync()).AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();
        }
    }
}
