using Microsoft.EntityFrameworkCore;
using SkillEntities.DataModels;
using SkillRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRepositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ManagementContext _dbContext;
        public UserRepository(ManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByEmail(string Email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == Email && user.DeletedAt == null && user.Status == true);
        }
    }
}
