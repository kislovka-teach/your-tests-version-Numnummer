using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IUserService
    {
        Task<ClaimsPrincipal?> GetUserPrincipalAsync(User user);
        Task<User?> GetUserByLoginAsync(string login);
    }
}
