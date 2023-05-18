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
        Task<User> GetUserById(int id);
        Task<GenModel<bool>> UserLogin(UserLogin credentials);

    }
}
