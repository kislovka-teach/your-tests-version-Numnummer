using DataAccess.Entities;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        public Product MakeRandomProduct()
        {
            return new Product()
            {
                Name = "slkcnaiof",
                Description="lknsaiofhdow",
                Price=234,
                Size="2L",
                FurnitureCategory=new()
                {
                    Name="naksjiow",
                    Description="scnioahduaw"
                }
            };
        }
    }
}
