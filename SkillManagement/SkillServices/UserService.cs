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

        #region Get User By Id
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Entity with given Id</returns>
        public async Task<User> GetUserById(int id)
        {
            return await _userGenRepo.GetByIdAsync(id);
        }
        #endregion

        #region Get User By Email
        /// <summary>
        /// Get User By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User Entity having given Email</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepo.GetUserByEmail(email);

        }
        #endregion

        #region Login

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>Boolean response</returns>
        public async Task<User> UserLogin(UserLogin credentials)
        {
            User user = await GetUserByEmail(credentials.UserName);

            if (user != null)
            {
                //if (Crypto.VerifyHashedPassword(user.Password, credentials.Password))
                //{
                //    return true;
                //}
                if(user.Password == credentials.Password)
                {
                    return user;
                }
            }
                return null;
        }
        #endregion
    }
}

