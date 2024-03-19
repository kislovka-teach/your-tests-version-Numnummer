using Domain.Abstractions;
using Domain.Abstractions.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService(IUserRepository repository, IConfiguration configuration) : IUserService
    {
        public async Task<string?> MakeJwtTokenAsync(string login, string password)
        {
            var user = await repository.GetUserAsync(login, password);
            if (user==null)
            {
                return null;
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["secret-key"]));
            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: sign
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
