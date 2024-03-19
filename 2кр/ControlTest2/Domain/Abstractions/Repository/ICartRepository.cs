using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repository
{
    public interface ICartRepository : IRepository
    {
        Task<Cart?> GetCartByUserLogin(string login);
        Task AddProductAsync(Product product, string userLogin);
        Task<Cart[]> GetAllCartsAsync();
    }
}
