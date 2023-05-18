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

        public async Task<User> GetUserById(int id)
        {
            return await _userGenRepo.GetByIdAsync(id);
        }

        public async Task<GenModel<User>> GetUserByEmail(string Email)
        {
            User user = await _userRepo.GetUserByEmail(Email);

            GenModel<User> Response = new();

            if (user == null)
            {
                Response.StatusCode = 200;
                Response.Message = "User Not Found";
                Response.Data = null;
                return Response;
            }

            Response.StatusCode = 200;
            Response.Message = "Success";
            Response.Data = user;
            return Response;

        }

        public async Task<GenModel<bool>> UserLogin(UserLogin Credentials)
        {
            GenModel<User> TempUser = await GetUserByEmail(Credentials.UserName);
            User user = TempUser.Data;
            GenModel<bool> Response = new();
            Response.StatusCode = 200;
            if (user == null)
            {
                
                Response.Message = "Invalid Credentials";
                Response.Data = false;
                return Response;
            }

            if(Crypto.VerifyHashedPassword(user.Password, Credentials.Password))
            {
               
                Response.Message = "Login Successfull";
                Response.Data = true;
                return Response;
            }
            else
            {
                Response.Message = "Invalid Credentials";
                Response.Data = false;
                return Response;
            }


        }
    }
}
