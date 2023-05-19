
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

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single entity of type T having given id</returns>
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List of entity of type T</returns>
        public IQueryable<T> GetAll()
        {
            return  _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> execption if any</returns>
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if any</returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if any</returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

       
    }
}