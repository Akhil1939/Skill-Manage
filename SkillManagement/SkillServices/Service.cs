using SkillRepositories.Interfaces;
using SkillServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillServices
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _genRepo;

        public Service(IRepository<T> genRepo)
        {
            _genRepo = genRepo;
        }
        public async Task Add(T entity)
        {
           await _genRepo.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            await _genRepo.DeleteAsync(entity);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(long id)
        {
           return await _genRepo.GetByIdAsync(id);
        }

        public Task Update(T entity)
        {
            return _genRepo.UpdateAsync(entity);
        }
    }
}
