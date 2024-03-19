using DataAccess.Entities;
using Domain.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task AddProductAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
        }

        public async Task<Product[]> GetProductsByCategoryAsync(int categoryId)
        {
            return await dbContext.Products.Where(prod => prod.FurnitureCategory.Id==categoryId).ToArrayAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
