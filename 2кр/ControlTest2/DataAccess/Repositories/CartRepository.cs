using DataAccess.Entities;
using Domain.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CartRepository(AppDbContext dbContext) : ICartRepository
    {
        public async Task AddProductAsync(Product product, string userLogin)
        {
            var cart = await dbContext.Carts.FirstOrDefaultAsync(cart => cart.User.Login == userLogin);
            cart?.Products.Add(product);
        }

        public async Task<Cart[]> GetAllCartsAsync()
        {
            return await dbContext.Carts.ToArrayAsync();
        }

        public async Task<Cart?> GetCartByUserLogin(string login)
        {
            return await dbContext.Carts.FirstOrDefaultAsync(c => c.User.Login == login);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
