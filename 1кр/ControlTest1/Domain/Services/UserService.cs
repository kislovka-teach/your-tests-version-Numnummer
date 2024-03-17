using Domain.Abstractions;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository=repository;
        }

        public async Task<User?> GetUserByLoginAsync(string login)
        {
            return await _repository.FindUserByLoginAsync(login);
        }

        public async Task<ClaimsPrincipal?> GetUserPrincipalAsync(User user)
        {
            var foundedUser = await _repository.FindUserAsync(user.Login, user.Password);
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
