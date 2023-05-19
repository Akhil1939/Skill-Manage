using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillServices.IServices
{
    public interface IService<T> where T : class
    {
        Task<T> GetById(long id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
