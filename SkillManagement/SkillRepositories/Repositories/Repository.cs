
using SkillRepositories.Interfaces;
using SkillEntities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace SkillRepositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ManagementContext _dbContext;
        private readonly DbSet<T> _dbSet;
       

        public Repository(ManagementContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();   
        }

        #region Get By Id

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single entity of type T having given id</returns>
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region Get All
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List of entity of type T</returns>
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        #endregion

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> execption if any</returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Update
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
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if any</returns>
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion


    }
}