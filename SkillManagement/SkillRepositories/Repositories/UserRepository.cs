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

        /// <summary>
        /// Get user by email id
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User entity if found else null user</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
            User user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email && user.DeletedAt == null && user.Status == true);
                if(user == null)
                {
                    return new User();
                }
                else
                {
                    return user;
                }
            }catch(Exception ex)
            {
                return new User();
            }
        }
    }
}
