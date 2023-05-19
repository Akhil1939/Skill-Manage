using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRepositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// get a single record by id of t entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single record of T entity with given id</returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// Get a list of all record of given entity
        /// </summary>
        /// <returns> List of given entity</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// add record of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if error occure</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Update any given entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if error occure</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete any given entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>execption if error occure</returns>
        Task DeleteAsync(T entity);
    }
}
