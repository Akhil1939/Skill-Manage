using SkillEntities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRepositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Single user entity having given email</returns>
        Task<User> GetUserByEmail(string email);
    }
}
