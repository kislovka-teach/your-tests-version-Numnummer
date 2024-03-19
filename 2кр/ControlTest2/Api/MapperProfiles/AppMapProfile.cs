using Api.Models;
using AutoMapper;
using DataAccess.Entities;

namespace Api.MapperProfiles
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<Product, ProductView>();
            CreateMap<Cart, CartView>();
        }
    }
}
