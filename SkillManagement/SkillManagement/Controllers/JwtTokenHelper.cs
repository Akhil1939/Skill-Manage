
using DemoMvcCore.Entities.Auth;
using Microsoft.IdentityModel.Tokens;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DemoMvcCore.Auth
{
    public static class JwtTokenHelper
    {
        public static string GenerateToken(JwtSetting jwtSetting, User user)
        {
            if (jwtSetting == null)
                return string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
               
                new Claim("CustomClaimForUser", JsonSerializer.Serialize(user)),
                new Claim("position", user.Position.ToString())
        };
           

            var token = new JwtSecurityToken(
                jwtSetting.Issuer,
                jwtSetting.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(1), // Default 5 mins, max 1 day
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
