using DataAccess;
using DataAccess.Entities;
using Domain.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<User?> GetUserAsync(string login, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user =>
                user.Password == password && user.Login==login);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
