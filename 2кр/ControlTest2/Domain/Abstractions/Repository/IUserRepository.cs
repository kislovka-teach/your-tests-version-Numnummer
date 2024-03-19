using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User?> GetUserAsync(string login, string password);
    }
}
