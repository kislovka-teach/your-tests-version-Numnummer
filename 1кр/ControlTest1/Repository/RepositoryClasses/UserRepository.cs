using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClasses
{
    public class UserRepository(AppDbContext dbContext) : IUserRepositiry
    {
        public async Task<User?> FindUserAsync(string login, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x =>
                x.Login == login && x.Password==password);
        }

        public async Task<User?> FindUserByLoginAsync(string login)
        {
            return await dbContext.Users.FindAsync(login);
        }

        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
