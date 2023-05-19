using SkillEntities.DataModels;
using SkillEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillServices.IServices
{
    public interface IUserService
    {

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single User having given id</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// user login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        Task<bool> UserLogin(UserLogin credentials);

    }
}
