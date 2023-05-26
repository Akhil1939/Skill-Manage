
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoMvcCore
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (IsLoginPage(context))
            {
                await _next(context);
                return;
            }

            if (IsErrorPages(context))
            {
                await _next(context);
                return ;
            }

            // Check if the user is authenticated
            if (!IsAuthenticated(context))
            {
                // Redirect the user to the login page with a temporary message
                context.Response.Redirect("/");
                return;
            }

            // Check if the user is authorized to access the requested resource
            if (!IsAuthorized(context))
            {
                // Redirect the user to the previous page with a temporary message

                context.Response.Redirect(context.Request.Headers.FirstOrDefault(key=>key.Key == "Referer").Value.ToString().Split('?')[0] + "?authorize=false");
                 
                return;
            }

            // User is authenticated and authorized, continue processing the request
            await _next(context);
        }

        private bool IsAuthenticated(HttpContext context)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKeyWhichCanBeAnything")),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                // Validate the token
                tokenHandler.ValidateToken(context.Request.Cookies["token"], tokenValidationParameters, out _);

                // Token is valid
                return true;
            }
            catch (Exception ex)
            {
                // Token validation failed
                return false;
            }
        }

        private bool IsAuthorized(HttpContext context)
        {
            // Check if the user is authorized based on their roles or claims
            // You can use context.User.HasClaim or any authorization mechanism
            // Return true if authorized, false otherwise
            var user = context.User.Claims;
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = context.Request.Cookies["token"];
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKeyWhichCanBeAnything")),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };



            var claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            if (claims != null)
            {
                var claim = claims.Claims.ToArray();
                if (context.Request.Path.Equals("/Skill/Home", StringComparison.OrdinalIgnoreCase) || context.Request.Path.StartsWithSegments("/Skill/SkillFilter", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (context.Request.Path.StartsWithSegments("/Skill/AddSkill", StringComparison.OrdinalIgnoreCase))
                {
                    if (claim[4].Value == "6")
                    {
                        return true;
                    }
                }
                else if (context.Request.Path.StartsWithSegments("/Skill/UpdateSkill", StringComparison.OrdinalIgnoreCase))
                {
                    if (claim[4].Value == "6" || claim[4].Value == "2" || claim[4].Value == "3") { return true; }
                }
                else if (context.Request.Path.StartsWithSegments("/Skill/DeleteSkill", StringComparison.OrdinalIgnoreCase))
                {
                    if (claim[4].Value == "6" || claim[4].Value == "2") { return true; }
                }
                else { return false; }

            }
            return false;

            // Implement your authorization logic here
        }

        private bool IsLoginPage(HttpContext context)
        {
            // Check if the requested path corresponds to the login page
            return context.Request.Path.Equals("/", StringComparison.OrdinalIgnoreCase);
        }
        private bool IsErrorPages(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/Home/Error", StringComparison.OrdinalIgnoreCase);
        }
    }
}
