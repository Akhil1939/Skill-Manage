
using SkillRepositories.Interfaces;
using SkillEntities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace SkillRepositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ManagementContext _dbContext;

        public Repository(ManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return  _dbContext.Set<T>().AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

       
    }
}