using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillRepositories.Interfaces;
using SkillServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SkillServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userGenRepo;
        private readonly IUserRepository _userRepo;


        public UserService(IRepository<User> userGenRepo, IUserRepository userRepo)
        {
            _userGenRepo = userGenRepo;
            _userRepo = userRepo;
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Entity with given Id</returns>
        public async Task<User> GetUserById(int id)
        {
            return await _userGenRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Get User By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User Entity having given Email</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _userRepo.GetUserByEmail(email);
            if (user == null)
            {   
                return new User();
            }
            return user;

        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>Boolean response</returns>
        public async Task<bool> UserLogin(UserLogin credentials)
        {
            User user = await GetUserByEmail(credentials.UserName);

            if (user == null)
            {
                return false;
            }

            if (Crypto.VerifyHashedPassword(user.Password, credentials.Password))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}

