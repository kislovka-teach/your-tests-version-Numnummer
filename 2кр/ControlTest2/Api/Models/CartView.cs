using DataAccess.Entities;

namespace Api.Models
{
    public class CartView
    {
        public Product[] Products { get; set; }
        public int Price { get; set; }
    }
}
