using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService(IUserRepositiry userRepositiry) : IUserService
    {

        public async Task<User?> GetUserByLoginAsync(string login)
        {
            return await userRepositiry.FindUserByLoginAsync(login);
        }

        public async Task<ClaimsPrincipal?> GetUserPrincipalAsync(User user)
        {
            var foundedUser = await userRepositiry.FindUserAsync(user.Login, user.Password);
            if (foundedUser==null)
            {
                return null;
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,foundedUser.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,foundedUser.Role)
            };
            var identity = new ClaimsIdentity(claims, "Cookie");
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
    }
}
