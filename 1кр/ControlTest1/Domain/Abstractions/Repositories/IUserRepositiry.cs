using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IUserRepositiry : IRepository
    {
        Task<User?> FindUserAsync(string login, string password);
        Task<User?> FindUserByLoginAsync(string login);
    }
}
